# Task 4 - Create API Controller and Backend Logic

Implement the backend API controller that receives search requests from the frontend, validates input, determines lookup type, and calls the MCommunityApiClient service.

## Status: Completed

## Dependencies: Task 3 - Implement MCommunityApiClient Service

## Steps to Complete:

[x] 1. Create API Controller
   [x] 1.Create `Controllers/ApiController.cs` inheriting from `ControllerBase`
   [x] 1.Add `[ApiController]` and `[Route("api")]` attributes
   [x] 1.Add constructor with dependency injection: `IMCommunityApiClient`, `ILogger<ApiController>`
   [x] 1.Add private readonly fields for injected dependencies

[x] 2. Create Lookup Endpoint Method
   [x] 2.Create `[HttpPost("lookup")]` action method `Lookup()`
   [x] 2.Accept `[FromBody] LookupRequestViewModel request` parameter
   [x] 2.Add `[Produces("application/json")]` attribute
   [x] 2.Return `Task<IActionResult>` (or `ActionResult<LookupResponse>`)
   [x] 2.Add XML documentation comments

[x] 3. Implement Input Validation
   [x] 3.Check `ModelState.IsValid` - return BadRequest if invalid
   [x] 3.Validate SearchTerm is not null or whitespace
   [x] 3.Validate ApplicationId and Password are provided
   [x] 3.Return LookupResponse.ErrorResult() with appropriate error message if validation fails
   [x] 3.Log validation failures

[x] 4. Implement Input Type Detection Logic
   [x] 4.Create private method `DetermineSearchType(string searchTerm)`
   [x] 4.Check length: 3-8 chars with alphanumeric only = Person
   [x] 4.Check length: 9-62 chars with alphanumeric/dash/underscore = Group
   [x] 4.Use regex patterns for validation: `^[a-zA-Z0-9]{3,8}$` and `^[a-zA-Z0-9_-]{9,62}$`
   [x] 4.Return enum or string: "person", "group", or "invalid"
   [x] 4.Log detection result

[x] 5. Implement Person Lookup Logic
   [x] 5.Create private async method `LookupPersonAsync(string uniqname, string appId, string password)`
   [x] 5.Call `_mcommunityClient.GetPersonAsync(uniqname, appId, password)`
   [x] 5.Handle null return (person not found) - return LookupResponse.NotFoundResult()
   [x] 5.Handle UnauthorizedException - return LookupResponse.ErrorResult() with "Invalid credentials"
   [x] 5.Handle ForbiddenException - return LookupResponse.ErrorResult() with "Insufficient permissions"
   [x] 5.On success, return LookupResponse.SuccessResult() with PersonData and type="person"
   [x] 5.Log lookup result (success/failure, uniqname)

[x] 6. Implement Group Lookup Logic
   [x] 6.Create private async method `LookupGroupAsync(string groupname, string appId, string password)`
   [x] 6.Call `_mcommunityClient.GetGroupAsync(groupname, appId, password)`
   [x] 6.Handle null return (group not found) - return LookupResponse.NotFoundResult()
   [x] 6.Handle UnauthorizedException - return LookupResponse.ErrorResult() with "Invalid credentials"
   [x] 6.Handle ForbiddenException - return LookupResponse.ErrorResult() with "Insufficient permissions"
   [x] 6.On success, return LookupResponse.SuccessResult() with GroupData and type="group"
   [x] 6.Log lookup result (success/failure, groupname)

[x] 7. Implement Main Lookup Method Logic
   [x] 7.Determine search type using `DetermineSearchType()`
   [x] 7.If invalid format, return BadRequest with helpful error message
   [x] 7.If "person", call `LookupPersonAsync()` and return result
   [x] 7.If "group", call `LookupGroupAsync()` and return result
   [x] 7.Wrap all logic in try-catch for unexpected errors
   [x] 7.Log unexpected errors with full details
   [x] 7.Return generic error response for unexpected exceptions

[x] 8. Add Error Handling
   [x] 8.Add catch block for HttpRequestException (network errors)
   [x] 8.Add catch block for TimeoutException
   [x] 8.Add catch block for JsonException (deserialization errors)
   [x] 8.Add catch block for generic Exception (unexpected errors)
   [x] 8.Return appropriate LookupResponse.ErrorResult() for each error type
   [x] 8.Log all errors with context and stack trace

[x] 9. Configure CORS (if needed)
   [x] 9.In Program.cs, add CORS policy for API endpoints
   [x] 9.Allow same-origin requests by default
   [x] 9.If frontend on different port, configure appropriate CORS policy
   [x] 9.Add `[EnableCors]` attribute to controller if necessary

[x] 10. Add Request/Response Logging
    10.1. Log incoming request with SearchTerm (sanitized) and timestamp
    10.2. Log outgoing response with success/error status and duration
    10.3. Do NOT log passwords or tokens
    10.4. Add correlation ID for request tracing (optional)

[x] 11. Update HomeController
    11.1. Open `Controllers/HomeController.cs`
    11.2. Verify Index() action returns View()
    11.3. Add XML documentation comments
    11.4. Remove unnecessary default actions (Privacy, etc.) if not needed

[x] 12. Test Controller Compilation
    12.1. Run `dotnet build` to verify controller compiles
    12.2. Review any warnings or errors
    12.3. Verify routing is configured correctly in Program.cs
    12.4. Ensure controllers are registered: `builder.Services.AddControllers()`

## Completion Notes:

Task 4 completed on November 19, 2025. API Controller and backend logic fully implemented:
- ApiController created inheriting from ControllerBase with [ApiController] and [Route("api")] attributes
- Constructor with IMCommunityApiClient and ILogger dependency injection
- Lookup endpoint method with [HttpPost("lookup")] accepting LookupRequestViewModel from body
- Input validation checks ModelState, SearchTerm, ApplicationId, and Password
- DetermineSearchType logic implemented in MCommunityHelpers (3-8 chars = person, 9-62 = group)
- LookupPersonAsync method calls GetPersonAsync and handles null (404), UnauthorizedException (401), ForbiddenException (403)
- LookupGroupAsync method calls GetGroupAsync with same error handling pattern
- Main Lookup method routes to person or group lookup based on search type detection
- Comprehensive error handling for HttpRequestException, TaskCanceledException, generic Exception
- Returns appropriate LookupResponse objects with error codes: INVALID_INPUT, MISSING_CREDENTIALS, INVALID_FORMAT, UNAUTHORIZED, FORBIDDEN, NETWORK_ERROR, TIMEOUT, INTERNAL_ERROR
- Request/response logging implemented (sanitized, no passwords/tokens logged)
- HomeController verified with Index action
- Controllers registered in Program.cs
- Controller compiles successfully

