using System.Text.RegularExpressions;

namespace MCommunityWeb.Helpers;

/// <summary>
/// Helper methods for working with MCommunity Distinguished Names (DNs)
/// and other MCommunity-specific operations.
/// </summary>
public static class MCommunityHelpers
{
    /// <summary>
    /// Constructs a person Distinguished Name from a uniqname.
    /// </summary>
    /// <param name="uniqname">The person's uniqname</param>
    /// <returns>DN in format: uid=uniqname,ou=People,dc=umich,dc=edu</returns>
    /// <example>
    /// GetPersonDn("bjensen") returns "uid=bjensen,ou=People,dc=umich,dc=edu"
    /// </example>
    public static string GetPersonDn(string uniqname)
    {
        return $"uid={uniqname},ou=People,dc=umich,dc=edu";
    }

    /// <summary>
    /// Constructs a group Distinguished Name from a group name.
    /// </summary>
    /// <param name="groupname">The group name</param>
    /// <returns>DN in format: cn=groupname,ou=User Groups,ou=Groups,dc=umich,dc=edu</returns>
    /// <example>
    /// GetGroupDn("mygroup") returns "cn=mygroup,ou=User Groups,ou=Groups,dc=umich,dc=edu"
    /// </example>
    public static string GetGroupDn(string groupname)
    {
        return $"cn={groupname},ou=User Groups,ou=Groups,dc=umich,dc=edu";
    }

    /// <summary>
    /// Constructs person DNs for multiple uniqnames.
    /// </summary>
    /// <param name="uniqnames">Collection of uniqnames</param>
    /// <returns>List of person DNs</returns>
    public static List<string> GetPersonDns(IEnumerable<string> uniqnames)
    {
        return uniqnames.Select(GetPersonDn).ToList();
    }

    /// <summary>
    /// Extracts the uniqname from a person Distinguished Name.
    /// </summary>
    /// <param name="dn">Person DN (e.g., "uid=bjensen,ou=People,dc=umich,dc=edu")</param>
    /// <returns>The uniqname, or null if DN format is invalid</returns>
    /// <example>
    /// ExtractUniqnameFromDn("uid=bjensen,ou=People,dc=umich,dc=edu") returns "bjensen"
    /// </example>
    public static string? ExtractUniqnameFromDn(string dn)
    {
        if (string.IsNullOrWhiteSpace(dn))
            return null;

        var match = Regex.Match(dn, @"uid=([^,]+)", RegexOptions.IgnoreCase);
        return match.Success ? match.Groups[1].Value : null;
    }

    /// <summary>
    /// Extracts the group name from a group Distinguished Name.
    /// </summary>
    /// <param name="dn">Group DN (e.g., "cn=mygroup,ou=User Groups,ou=Groups,dc=umich,dc=edu")</param>
    /// <returns>The group name, or null if DN format is invalid</returns>
    /// <example>
    /// ExtractGroupnameFromDn("cn=mygroup,ou=User Groups,ou=Groups,dc=umich,dc=edu") returns "mygroup"
    /// </example>
    public static string? ExtractGroupnameFromDn(string dn)
    {
        if (string.IsNullOrWhiteSpace(dn))
            return null;

        var match = Regex.Match(dn, @"cn=([^,]+)", RegexOptions.IgnoreCase);
        return match.Success ? match.Groups[1].Value : null;
    }

    /// <summary>
    /// Determines if a search term is a uniqname or group name based on length and format.
    /// </summary>
    /// <param name="searchTerm">The search term to evaluate</param>
    /// <returns>"person" for uniqname, "group" for group name, "invalid" for invalid format</returns>
    public static string DetermineSearchType(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return "invalid";

        // Uniqname: 3-8 alphanumeric characters
        if (Regex.IsMatch(searchTerm, @"^[a-zA-Z0-9]{3,8}$"))
            return "person";

        // Group: 9-62 characters (alphanumeric, dash, underscore)
        if (Regex.IsMatch(searchTerm, @"^[a-zA-Z0-9_-]{9,62}$"))
            return "group";

        return "invalid";
    }
}
