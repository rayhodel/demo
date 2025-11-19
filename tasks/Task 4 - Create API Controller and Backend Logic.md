# Task 4 - Create API Controller and Backend Logic

Implement the backend API controller that receives search requests from the frontend, validates input, determines lookup type, and calls the MCommunityApiClient service.

## Status: Pending

## Dependencies: Task 3 - Implement MCommunityApiClient Service

## Steps to Complete:

1. Create API Controller
   1.1. Create `Controllers/ApiController.cs` inheriting from `ControllerBase`
   1.2. Add `[ApiController]` and `[Route("api")]` attributes
   1.3. Add constructor with dependency injection: `IMCommunityApiClient`, `ILogger<ApiController>`
   1.4. Add private readonly fields for injected dependencies

2. Create Lookup Endpoint Method
   2.1. Create `[HttpPost("lookup")]` action method `Lookup()`
   2.2. Accept `[FromBody] LookupRequestViewModel request` parameter
   2.3. Add `[Produces("application/json")]` attribute
   2.4. Return `Task<IActionResult>` (or `ActionResult<LookupResponse>`)
   2.5. Add XML documentation comments

3. Implement Input Validation
   3.1. Check `ModelState.IsValid` - return BadRequest if invalid
   3.2. Validate SearchTerm is not null or whitespace
   3.3. Validate ApplicationId and Password are provided
   3.4. Return LookupResponse.ErrorResult() with appropriate error message if validation fails
   3.5. Log validation failures

4. Implement Input Type Detection Logic
   4.1. Create private method `DetermineSearchType(string searchTerm)`
   4.2. Check length: 3-8 chars with alphanumeric only = Person
   4.3. Check length: 9-62 chars with alphanumeric/dash/underscore = Group
   4.4. Use regex patterns for validation: `^[a-zA-Z0-9]{3,8}$` and `^[a-zA-Z0-9_-]{9,62}$`
   4.5. Return enum or string: "person", "group", or "invalid"
   4.6. Log detection result

5. Implement Person Lookup Logic
   5.1. Create private async method `LookupPersonAsync(string uniqname, string appId, string password)`
   5.2. Call `_mcommunityClient.GetPersonAsync(uniqname, appId, password)`
   5.3. Handle null return (person not found) - return LookupResponse.NotFoundResult()
   5.4. Handle UnauthorizedException - return LookupResponse.ErrorResult() with "Invalid credentials"
   5.5. Handle ForbiddenException - return LookupResponse.ErrorResult() with "Insufficient permissions"
   5.6. On success, return LookupResponse.SuccessResult() with PersonData and type="person"
   5.7. Log lookup result (success/failure, uniqname)

6. Implement Group Lookup Logic
   6.1. Create private async method `LookupGroupAsync(string groupname, string appId, string password)`
   6.2. Call `_mcommunityClient.GetGroupAsync(groupname, appId, password)`
   6.3. Handle null return (group not found) - return LookupResponse.NotFoundResult()
   6.4. Handle UnauthorizedException - return LookupResponse.ErrorResult() with "Invalid credentials"
   6.5. Handle ForbiddenException - return LookupResponse.ErrorResult() with "Insufficient permissions"
   6.6. On success, return LookupResponse.SuccessResult() with GroupData and type="group"
   6.7. Log lookup result (success/failure, groupname)

7. Implement Main Lookup Method Logic
   7.1. Determine search type using `DetermineSearchType()`
   7.2. If invalid format, return BadRequest with helpful error message
   7.3. If "person", call `LookupPersonAsync()` and return result
   7.4. If "group", call `LookupGroupAsync()` and return result
   7.5. Wrap all logic in try-catch for unexpected errors
   7.6. Log unexpected errors with full details
   7.7. Return generic error response for unexpected exceptions

8. Add Error Handling
   8.1. Add catch block for HttpRequestException (network errors)
   8.2. Add catch block for TimeoutException
   8.3. Add catch block for JsonException (deserialization errors)
   8.4. Add catch block for generic Exception (unexpected errors)
   8.5. Return appropriate LookupResponse.ErrorResult() for each error type
   8.6. Log all errors with context and stack trace

9. Configure CORS (if needed)
   9.1. In Program.cs, add CORS policy for API endpoints
   9.2. Allow same-origin requests by default
   9.3. If frontend on different port, configure appropriate CORS policy
   9.4. Add `[EnableCors]` attribute to controller if necessary

10. Add Request/Response Logging
    10.1. Log incoming request with SearchTerm (sanitized) and timestamp
    10.2. Log outgoing response with success/error status and duration
    10.3. Do NOT log passwords or tokens
    10.4. Add correlation ID for request tracing (optional)

11. Update HomeController
    11.1. Open `Controllers/HomeController.cs`
    11.2. Verify Index() action returns View()
    11.3. Add XML documentation comments
    11.4. Remove unnecessary default actions (Privacy, etc.) if not needed

12. Test Controller Compilation
    12.1. Run `dotnet build` to verify controller compiles
    12.2. Review any warnings or errors
    12.3. Verify routing is configured correctly in Program.cs
    12.4. Ensure controllers are registered: `builder.Services.AddControllers()`

## Completion Notes:

