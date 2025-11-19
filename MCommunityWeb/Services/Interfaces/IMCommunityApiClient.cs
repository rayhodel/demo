using MCommunityWeb.Models.ApiModels;

namespace MCommunityWeb.Services.Interfaces;

/// <summary>
/// Interface for the MCommunity API client service.
/// Provides methods for authenticating and retrieving person/group data from MCommunity.
/// </summary>
public interface IMCommunityApiClient
{
    /// <summary>
    /// Retrieves person data by uniqname.
    /// </summary>
    /// <param name="uniqname">The person's uniqname (3-8 alphanumeric characters)</param>
    /// <param name="appId">MCommunity API Application ID</param>
    /// <param name="password">Password for the Application ID</param>
    /// <returns>PersonData if found, null if not found</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when credentials are invalid</exception>
    /// <exception cref="HttpRequestException">Thrown when API request fails</exception>
    Task<PersonData?> GetPersonAsync(string uniqname, string appId, string password);

    /// <summary>
    /// Retrieves group data by group name.
    /// </summary>
    /// <param name="groupname">The group name (9-62 characters)</param>
    /// <param name="appId">MCommunity API Application ID</param>
    /// <param name="password">Password for the Application ID</param>
    /// <returns>GroupData if found, null if not found</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when credentials are invalid</exception>
    /// <exception cref="HttpRequestException">Thrown when API request fails</exception>
    Task<GroupData?> GetGroupAsync(string groupname, string appId, string password);
}
