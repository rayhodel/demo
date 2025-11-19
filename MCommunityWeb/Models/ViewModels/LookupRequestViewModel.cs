using System.ComponentModel.DataAnnotations;

namespace MCommunityWeb.Models.ViewModels;

/// <summary>
/// View model for lookup requests from the client.
/// Includes validation for search term and credentials.
/// </summary>
public class LookupRequestViewModel
{
    /// <summary>
    /// The search term - can be a uniqname (3-8 chars) or group name (9-62 chars).
    /// Uniqname: alphanumeric only
    /// Group: alphanumeric with dash and underscore allowed
    /// </summary>
    [Required(ErrorMessage = "Search term is required")]
    [RegularExpression(@"^[a-zA-Z0-9]{3,8}$|^[a-zA-Z0-9_-]{9,62}$",
        ErrorMessage = "Invalid format. Uniqname: 3-8 alphanumeric characters. Group: 9-62 characters (alphanumeric, dash, underscore).")]
    public string SearchTerm { get; set; } = string.Empty;

    /// <summary>
    /// MCommunity API Application ID (Distinguished Name).
    /// Format: cn=mcapi-dept-usage,ou=apiusers,o=services
    /// </summary>
    [Required(ErrorMessage = "Application ID is required")]
    public string ApplicationId { get; set; } = string.Empty;

    /// <summary>
    /// Password for the Application ID.
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
