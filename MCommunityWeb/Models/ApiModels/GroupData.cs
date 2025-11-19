using System.Text.Json.Serialization;

namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Represents group data from the MCommunity API.
/// </summary>
public class GroupData
{
    /// <summary>
    /// Distinguished Name of the group.
    /// Format: cn=groupname,ou=User Groups,ou=Groups,dc=umich,dc=edu
    /// </summary>
    [JsonPropertyName("dn")]
    public string? Dn { get; set; }

    /// <summary>
    /// Common names of the group (array - group can have multiple names).
    /// </summary>
    [JsonPropertyName("cn")]
    public List<string>? Cn { get; set; }

    /// <summary>
    /// Group email local part (becomes email@umich.edu).
    /// </summary>
    [JsonPropertyName("umichGroupEmail")]
    public string? UmichGroupEmail { get; set; }

    /// <summary>
    /// Group owners (array of owner distinguished names).
    /// Application ID must be an owner to access group data.
    /// </summary>
    [JsonPropertyName("owner")]
    public List<string>? Owner { get; set; }

    /// <summary>
    /// Group members (array of member distinguished names).
    /// </summary>
    [JsonPropertyName("member")]
    public List<string>? Member { get; set; }

    /// <summary>
    /// Description of the group.
    /// </summary>
    [JsonPropertyName("umichDescription")]
    public string? UmichDescription { get; set; }

    /// <summary>
    /// Timestamp when the group was last modified.
    /// </summary>
    [JsonPropertyName("modifyTimestamp")]
    public string? ModifyTimestamp { get; set; }

    /// <summary>
    /// Timestamp when the group was created.
    /// </summary>
    [JsonPropertyName("createTimestamp")]
    public string? CreateTimestamp { get; set; }
}
