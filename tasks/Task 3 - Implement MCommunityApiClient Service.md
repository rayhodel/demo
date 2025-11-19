# Task 3 - Implement MCommunityApiClient Service

Create the service layer that handles all communication with the MCommunity API, including authentication, token management, and person/group lookups.

## Status: Pending

## Dependencies: Task 2 - Implement API Models and Data Structures

## Steps to Complete:

1. Create Service Interface
   1.1. Create `Services/Interfaces/IMCommunityApiClient.cs`
   1.2. Define `Task<PersonData> GetPersonAsync(string uniqname, string appId, string password)` method signature
   1.3. Define `Task<GroupData> GetGroupAsync(string groupname, string appId, string password)` method signature
   1.4. Add XML documentation comments describing interface purpose and method behaviors

2. Create MCommunityApiClient Service Class
   2.1. Create `Services/MCommunityApiClient.cs` implementing `IMCommunityApiClient`
   2.2. Add private fields: `_httpClient`, `_logger`, `_options`
   2.3. Add constructor with dependency injection: `HttpClient`, `ILogger<MCommunityApiClient>`, `IOptions<MCommunityApiOptions>`
   2.4. Add private fields for token caching: `_accessToken`, `_refreshToken`, `_tokenExpiration`, `_currentAppId`
   2.5. Add thread-safety lock object for token operations

3. Implement Authentication Methods
   3.1. Create private `GetAccessTokenAsync(string appId, string password)` method
   3.2. Build TokenRequest object with username (appId) and password
   3.3. Serialize to JSON and POST to `/token/` endpoint
   3.4. Deserialize TokenResponse and cache tokens with expiration time
   3.5. Log authentication success/failure
   3.6. Handle HttpRequestException for 401 errors

4. Implement Token Refresh Method
   4.1. Create private `RefreshAccessTokenAsync()` method
   4.2. Build RefreshTokenRequest with cached refresh token
   4.3. POST to `/token/refresh/` endpoint
   4.4. Update cached access token and expiration
   4.5. Log refresh success/failure
   4.6. Handle errors and fall back to new token request if refresh fails

5. Implement Token Management Logic
   5.1. Create private `EnsureValidTokenAsync(string appId, string password)` method
   5.2. Check if current token is valid and for same appId
   5.3. If no token or expired (within 5 minutes of expiration), get new token
   5.4. If different appId than cached, clear cache and get new token
   5.5. Return valid access token
   5.6. Add thread-safe locking around token operations

6. Implement Authenticated Request Helper
   6.1. Create private `CreateAuthenticatedRequestAsync(HttpMethod method, string endpoint, string appId, string password)` method
   6.2. Call `EnsureValidTokenAsync()` to get valid token
   6.3. Create HttpRequestMessage with method and full URL (BaseUrl + endpoint)
   6.4. Add Authorization header: `Bearer {token}`
   6.5. Set appropriate Content-Type and Accept headers
   6.6. Return configured HttpRequestMessage

7. Implement GetPersonAsync Method
   7.1. Validate uniqname parameter (not null/empty)
   7.2. Create authenticated GET request to `/people/{uniqname}/`
   7.3. Send request via HttpClient
   7.4. Handle 404 response (return null)
   7.5. Handle 401 response (throw UnauthorizedException)
   7.6. Handle 403 response (throw ForbiddenException)
   7.7. Deserialize successful response to PersonData
   7.8. Log operation with uniqname (success/failure)
   7.9. Return PersonData or null

8. Implement GetGroupAsync Method
   8.1. Validate groupname parameter (not null/empty)
   8.2. Create authenticated GET request to `/groups/{groupname}/`
   8.3. Send request via HttpClient
   8.4. Handle 404 response (return null)
   8.5. Handle 401 response (throw UnauthorizedException)
   8.6. Handle 403 response (throw ForbiddenException)
   8.7. Deserialize successful response to GroupData
   8.8. Log operation with groupname (success/failure)
   8.9. Return GroupData or null

9. Implement Error Handling and Logging
   9.1. Add try-catch blocks for HttpRequestException, JsonException, OperationCanceledException
   9.2. Log detailed errors with context (uniqname/groupname, HTTP status, error message)
   9.3. Wrap exceptions in meaningful custom exceptions where appropriate
   9.4. Never log passwords or full tokens (mask if necessary)
   9.5. Log timing information for performance monitoring (optional)

10. Configure HTTP Client in Program.cs
    10.1. Register MCommunityApiClient as scoped service
    10.2. Configure HttpClient with IHttpClientFactory
    10.3. Set base address from configuration
    10.4. Configure timeout (30 seconds default)
    10.5. Add appropriate default request headers

11. Add XML Documentation
    11.1. Add comprehensive XML comments to all public methods
    11.2. Document parameters, return values, and exceptions
    11.3. Add usage examples in XML comments
    11.4. Document thread-safety considerations

12. Test Service Compilation and Registration
    12.1. Run `dotnet build` to verify service compiles
    12.2. Verify dependency injection registration in Program.cs
    12.3. Add logging configuration for `MCommunityWeb.Services` namespace
    12.4. Review any compiler warnings

## Completion Notes:

