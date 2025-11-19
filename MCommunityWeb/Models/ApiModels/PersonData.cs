using System.Text.Json.Serialization;

namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Represents person data from the MCommunity API.
/// Field names match the Swagger specification at https://mcommunity.umich.edu/api/doc/schema/swagger-ui/
/// </summary>
public class PersonData
{
    /// <summary>
    /// Distinguished Name of the person.
    /// Format: uid=uniqname,ou=People,dc=umich,dc=edu
    /// Note: Swagger uses 'entry_dn' not 'dn'
    /// </summary>
    [JsonPropertyName("entry_dn")]
    public string? Dn { get; set; }

    /// <summary>
    /// Uniqname (unique username identifier).
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// Full display name of the person.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// First name (given name).
    /// </summary>
    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    /// <summary>
    /// Last name (surname).
    /// Note: Swagger uses 'surname' not 'sn'
    /// </summary>
    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    /// <summary>
    /// Common names (can have multiple values).
    /// </summary>
    [JsonPropertyName("cn")]
    public List<string>? Cn { get; set; }

    /// <summary>
    /// Email addresses (array - person can have multiple).
    /// </summary>
    [JsonPropertyName("mail")]
    public List<string>? Mail { get; set; }

    /// <summary>
    /// Phone numbers (array - person can have multiple).
    /// </summary>
    [JsonPropertyName("telephoneNumber")]
    public List<string>? TelephoneNumber { get; set; }

    /// <summary>
    /// Job titles (array - person can have multiple).
    /// </summary>
    [JsonPropertyName("umichTitle")]
    public List<string>? Title { get; set; }

    /// <summary>
    /// Organizational units / departments (array).
    /// </summary>
    [JsonPropertyName("ou")]
    public List<string>? Ou { get; set; }

    /// <summary>
    /// Institutional roles / affiliations (e.g., Staff, Faculty, Student, Alumni).
    /// Note: Swagger uses 'umichInstRoles' not 'umichAffiliation'
    /// </summary>
    [JsonPropertyName("umichInstRoles")]
    public List<string>? UmichAffiliation { get; set; }

    /// <summary>
    /// Group memberships (array of group distinguished names).
    /// </summary>
    [JsonPropertyName("groupMembership")]
    public List<string>? GroupMembership { get; set; }
}
