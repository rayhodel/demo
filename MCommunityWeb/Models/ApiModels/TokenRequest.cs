using System.Text.Json.Serialization;

namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Request model for obtaining an access token from the MCommunity API.
/// </summary>
public class TokenRequest
{
    /// <summary>
    /// The Application ID (Distinguished Name) for authentication.
    /// Format: cn=mcapi-dept-usage,ou=apiusers,o=services
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The password for the Application ID.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
