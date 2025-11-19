using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using MCommunityWeb.Models.ApiModels;
using MCommunityWeb.Services.Interfaces;

namespace MCommunityWeb.Services;

/// <summary>
/// Service for interacting with the MCommunity API.
/// Handles authentication, token management, and person/group lookups.
/// </summary>
public class MCommunityApiClient : IMCommunityApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MCommunityApiClient> _logger;
    private readonly MCommunityApiOptions _options;
    
    // Token caching fields
    private string? _accessToken;
    private string? _refreshToken;
    private DateTime _tokenExpiration;
    private string? _currentAppId;
    private readonly object _tokenLock = new();

    /// <summary>
    /// Initializes a new instance of MCommunityApiClient.
    /// </summary>
    public MCommunityApiClient(
        HttpClient httpClient, 
        ILogger<MCommunityApiClient> logger,
        IOptions<MCommunityApiOptions> options)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options.Value;
        
        // Configure HttpClient timeout
        _httpClient.Timeout = TimeSpan.FromSeconds(_options.RequestTimeoutSeconds);
    }

    /// <inheritdoc/>
    public async Task<PersonData?> GetPersonAsync(string uniqname, string appId, string password)
    {
        if (string.IsNullOrWhiteSpace(uniqname))
            throw new ArgumentNullException(nameof(uniqname));

        try
        {
            _logger.LogInformation("Looking up person: {Uniqname}", uniqname);

            var request = await CreateAuthenticatedRequestAsync(
                HttpMethod.Get, 
                $"people/{uniqname}/", 
                appId, 
                password);

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("Person not found: {Uniqname}", uniqname);
                return null;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _logger.LogWarning("Authentication failed for app ID");
                throw new UnauthorizedAccessException("Invalid API credentials");
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _logger.LogWarning("Insufficient permissions to view person: {Uniqname}", uniqname);
                throw new UnauthorizedAccessException("Insufficient permissions");
            }

            response.EnsureSuccessStatusCode();

            var personData = await response.Content.ReadFromJsonAsync<PersonData>();
            
            _logger.LogInformation("Person found: {Uniqname}, DisplayName: {DisplayName}", 
                uniqname, personData?.DisplayName);

            return personData;
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error retrieving person: {Uniqname}", uniqname);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error retrieving person: {Uniqname}", uniqname);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<GroupData?> GetGroupAsync(string groupname, string appId, string password)
    {
        if (string.IsNullOrWhiteSpace(groupname))
            throw new ArgumentNullException(nameof(groupname));

        try
        {
            _logger.LogInformation("Looking up group: {Groupname}", groupname);

            var request = await CreateAuthenticatedRequestAsync(
                HttpMethod.Get, 
                $"groups/{groupname}/", 
                appId, 
                password);

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("Group not found: {Groupname}", groupname);
                return null;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _logger.LogWarning("Authentication failed for app ID");
                throw new UnauthorizedAccessException("Invalid API credentials");
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _logger.LogWarning("Insufficient permissions to view group: {Groupname}", groupname);
                throw new UnauthorizedAccessException("Insufficient permissions");
            }

            response.EnsureSuccessStatusCode();

            var groupData = await response.Content.ReadFromJsonAsync<GroupData>();
            
            _logger.LogInformation("Group found: {Groupname}", groupname);

            return groupData;
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error retrieving group: {Groupname}", groupname);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error retrieving group: {Groupname}", groupname);
            throw;
        }
    }

    /// <summary>
    /// Creates an authenticated HTTP request with Bearer token.
    /// </summary>
    private async Task<HttpRequestMessage> CreateAuthenticatedRequestAsync(
        HttpMethod method, 
        string endpoint, 
        string appId, 
        string password)
    {
        var token = await EnsureValidTokenAsync(appId, password);

        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return request;
    }

    /// <summary>
    /// Ensures a valid access token is available, obtaining or refreshing as needed.
    /// </summary>
    private async Task<string> EnsureValidTokenAsync(string appId, string password)
    {
        lock (_tokenLock)
        {
            // If app ID changed, clear cached tokens
            if (_currentAppId != null && _currentAppId != appId)
            {
                _logger.LogDebug("Application ID changed, clearing cached tokens");
                _accessToken = null;
                _refreshToken = null;
                _tokenExpiration = DateTime.MinValue;
            }

            // If token is valid and not expired (with 5-minute buffer), reuse it
            if (!string.IsNullOrEmpty(_accessToken) && 
                DateTime.UtcNow < _tokenExpiration.AddMinutes(-5))
            {
                _logger.LogDebug("Reusing cached access token");
                return _accessToken;
            }
        }

        // Need new token - do this outside the lock to allow async
        _logger.LogInformation("Obtaining new access token");
        var tokenResponse = await GetAccessTokenAsync(appId, password);

        lock (_tokenLock)
        {
            _accessToken = tokenResponse.Access;
            _refreshToken = tokenResponse.Refresh;
            _currentAppId = appId;
            _tokenExpiration = DateTime.UtcNow.AddMinutes(_options.TokenExpirationMinutes);
            
            _logger.LogDebug("Access token cached, expires at {Expiration}", _tokenExpiration);
            
            return _accessToken;
        }
    }

    /// <summary>
    /// Obtains an access token from the MCommunity API.
    /// </summary>
    private async Task<TokenResponse> GetAccessTokenAsync(string appId, string password)
    {
        try
        {
            _logger.LogInformation("Authenticating with MCommunity API");

            var tokenRequest = new TokenRequest
            {
                Username = appId,
                Password = password
            };

            var json = JsonSerializer.Serialize(tokenRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("token/", content);

            // Log response for debugging
            var responseBody = await response.Content.ReadAsStringAsync();
            _logger.LogDebug("Token API Response: Status={StatusCode}, Body={Body}", 
                response.StatusCode, responseBody.Substring(0, Math.Min(500, responseBody.Length)));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _logger.LogWarning("Authentication failed - invalid credentials");
                throw new UnauthorizedAccessException("Invalid API credentials");
            }

            response.EnsureSuccessStatusCode();

            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseBody);

            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.Access))
            {
                throw new InvalidOperationException("Token response was null or missing access token");
            }

            _logger.LogInformation("Successfully authenticated with MCommunity API");

            return tokenResponse;
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error during authentication");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during authentication");
            throw;
        }
    }
}
