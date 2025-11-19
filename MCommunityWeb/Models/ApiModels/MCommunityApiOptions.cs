namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Configuration options for the MCommunity API.
/// Bound from appsettings.json MCommunityApi section.
/// </summary>
public class MCommunityApiOptions
{
    /// <summary>
    /// Base URL for the MCommunity API.
    /// Default: https://mcommunity.umich.edu/api
    /// </summary>
    public string BaseUrl { get; set; } = "https://mcommunity.umich.edu/api";

    /// <summary>
    /// Token expiration time in minutes.
    /// Tokens typically expire after 1 hour, we cache for 55 minutes to be safe.
    /// </summary>
    public int TokenExpirationMinutes { get; set; } = 55;

    /// <summary>
    /// HTTP request timeout in seconds.
    /// </summary>
    public int RequestTimeoutSeconds { get; set; } = 30;
}
