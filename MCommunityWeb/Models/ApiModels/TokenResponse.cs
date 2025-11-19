using System.Text.Json.Serialization;

namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Response model containing access and refresh tokens from the MCommunity API.
/// </summary>
public class TokenResponse
{
    /// <summary>
    /// The access token used for authenticating API requests.
    /// Valid for approximately 1 hour.
    /// </summary>
    [JsonPropertyName("access")]
    public string Access { get; set; } = string.Empty;

    /// <summary>
    /// The refresh token used to obtain a new access token.
    /// Can only be used once.
    /// </summary>
    [JsonPropertyName("refresh")]
    public string Refresh { get; set; } = string.Empty;
}
