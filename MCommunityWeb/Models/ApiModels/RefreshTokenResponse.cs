using System.Text.Json.Serialization;

namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Response model containing a refreshed access token.
/// </summary>
public class RefreshTokenResponse
{
    /// <summary>
    /// The new access token.
    /// Valid for approximately 1 hour.
    /// </summary>
    [JsonPropertyName("access")]
    public string Access { get; set; } = string.Empty;
}
