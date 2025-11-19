using System.Text.Json.Serialization;

namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Request model for refreshing an access token.
/// </summary>
public class RefreshTokenRequest
{
    /// <summary>
    /// The refresh token received from the initial token request.
    /// </summary>
    [JsonPropertyName("refresh")]
    public string Refresh { get; set; } = string.Empty;
}
