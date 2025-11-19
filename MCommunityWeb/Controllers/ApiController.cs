using Microsoft.AspNetCore.Mvc;
using MCommunityWeb.Helpers;
using MCommunityWeb.Models.ApiModels;
using MCommunityWeb.Models.ViewModels;
using MCommunityWeb.Services.Interfaces;

namespace MCommunityWeb.Controllers;

/// <summary>
/// API controller for MCommunity lookup operations.
/// </summary>
[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly IMCommunityApiClient _mcommunityClient;
    private readonly ILogger<ApiController> _logger;

    public ApiController(
        IMCommunityApiClient mcommunityClient,
        ILogger<ApiController> logger)
    {
        _mcommunityClient = mcommunityClient;
        _logger = logger;
    }

    /// <summary>
    /// Performs a lookup for a person or group based on the search term.
    /// Auto-detects whether the search is for a person (uniqname) or group based on input format.
    /// </summary>
    /// <param name="request">Lookup request containing search term and credentials</param>
    /// <returns>LookupResponse with person/group data or error information</returns>
    [HttpPost("lookup")]
    [Produces("application/json")]
    public async Task<ActionResult<LookupResponse>> Lookup([FromBody] LookupRequestViewModel request)
    {
        try
        {
            // Validate model
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                
                _logger.LogWarning("Invalid lookup request: {Errors}", errors);
                return BadRequest(LookupResponse.ErrorResult(errors, "INVALID_INPUT"));
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                return BadRequest(LookupResponse.ErrorResult(
                    "Search term is required", "INVALID_INPUT"));
            }

            if (string.IsNullOrWhiteSpace(request.ApplicationId) || 
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(LookupResponse.ErrorResult(
                    "API credentials are required. Please configure your settings.", 
                    "MISSING_CREDENTIALS"));
            }

            _logger.LogInformation("Lookup request for: {SearchTerm}", request.SearchTerm);

            // Determine search type (person or group)
            var searchType = MCommunityHelpers.DetermineSearchType(request.SearchTerm);

            if (searchType == "invalid")
            {
                return BadRequest(LookupResponse.ErrorResult(
                    "Invalid format. Uniqname: 3-8 alphanumeric characters. Group: 9-62 characters (alphanumeric, dash, underscore).",
                    "INVALID_FORMAT"));
            }

            // Perform appropriate lookup
            if (searchType == "person")
            {
                return await LookupPersonAsync(
                    request.SearchTerm, 
                    request.ApplicationId, 
                    request.Password);
            }
            else // searchType == "group"
            {
                return await LookupGroupAsync(
                    request.SearchTerm, 
                    request.ApplicationId, 
                    request.Password);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "Unauthorized access during lookup");
            return Unauthorized(LookupResponse.ErrorResult(
                ex.Message.Contains("credentials") 
                    ? "Invalid API credentials. Please check your settings." 
                    : "You don't have permission to view this information.",
                ex.Message.Contains("credentials") ? "UNAUTHORIZED" : "FORBIDDEN"));
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error during lookup");
            return StatusCode(500, LookupResponse.ErrorResult(
                "Unable to connect to MCommunity API. Please try again.",
                "NETWORK_ERROR"));
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogWarning(ex, "Request timeout during lookup");
            return StatusCode(408, LookupResponse.ErrorResult(
                "Request timed out. Please try again.",
                "TIMEOUT"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during lookup");
            return StatusCode(500, LookupResponse.ErrorResult(
                "An unexpected error occurred. Please try again.",
                "INTERNAL_ERROR"));
        }
    }

    /// <summary>
    /// Performs a person lookup by uniqname.
    /// </summary>
    private async Task<ActionResult<LookupResponse>> LookupPersonAsync(
        string uniqname, 
        string appId, 
        string password)
    {
        try
        {
            var personData = await _mcommunityClient.GetPersonAsync(uniqname, appId, password);

            if (personData == null)
            {
                _logger.LogInformation("Person not found: {Uniqname}", uniqname);
                return NotFound(LookupResponse.NotFoundResult(uniqname));
            }

            _logger.LogInformation("Person lookup successful: {Uniqname}", uniqname);
            return Ok(LookupResponse.SuccessResult(personData, "person"));
        }
        catch (UnauthorizedAccessException)
        {
            throw; // Re-throw to be handled by main catch block
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during person lookup: {Uniqname}", uniqname);
            throw;
        }
    }

    /// <summary>
    /// Performs a group lookup by group name.
    /// </summary>
    private async Task<ActionResult<LookupResponse>> LookupGroupAsync(
        string groupname, 
        string appId, 
        string password)
    {
        try
        {
            var groupData = await _mcommunityClient.GetGroupAsync(groupname, appId, password);

            if (groupData == null)
            {
                _logger.LogInformation("Group not found: {Groupname}", groupname);
                return NotFound(LookupResponse.NotFoundResult(groupname));
            }

            _logger.LogInformation("Group lookup successful: {Groupname}", groupname);
            return Ok(LookupResponse.SuccessResult(groupData, "group"));
        }
        catch (UnauthorizedAccessException)
        {
            throw; // Re-throw to be handled by main catch block
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during group lookup: {Groupname}", groupname);
            throw;
        }
    }
}
