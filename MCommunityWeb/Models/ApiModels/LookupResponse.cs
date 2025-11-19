namespace MCommunityWeb.Models.ApiModels;

/// <summary>
/// Standardized response wrapper for API lookups.
/// </summary>
public class LookupResponse
{
    /// <summary>
    /// Indicates whether the lookup was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// The result data (PersonData or GroupData).
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// Error message if the lookup failed.
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// Type of result: "person" or "group".
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Error code for programmatic error handling.
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Timestamp of the response.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Creates a successful lookup response.
    /// </summary>
    public static LookupResponse SuccessResult(object data, string type)
    {
        return new LookupResponse
        {
            Success = true,
            Data = data,
            Type = type,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Creates an error response.
    /// </summary>
    public static LookupResponse ErrorResult(string error, string? errorCode = null)
    {
        return new LookupResponse
        {
            Success = false,
            Error = error,
            ErrorCode = errorCode,
            Timestamp = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Creates a not found response.
    /// </summary>
    public static LookupResponse NotFoundResult(string searchTerm)
    {
        return new LookupResponse
        {
            Success = false,
            Error = $"No results found for '{searchTerm}'.",
            ErrorCode = "NOT_FOUND",
            Timestamp = DateTime.UtcNow
        };
    }
}
