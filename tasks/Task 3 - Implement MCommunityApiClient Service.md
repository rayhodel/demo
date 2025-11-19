# Task 3 - Implement MCommunityApiClient Service

Create the service layer that handles all communication with the MCommunity API, including authentication, token management, and person/group lookups.

## Status: Completed

## Dependencies: Task 2 - Implement API Models and Data Structures

## Steps to Complete:

[x] 1. Create Service Interface
   [x] 1.Create `Services/Interfaces/IMCommunityApiClient.cs`
   [x] 1.Define `Task<PersonData> GetPersonAsync(string uniqname, string appId, string password)` method signature
   [x] 1.Define `Task<GroupData> GetGroupAsync(string groupname, string appId, string password)` method signature
   [x] 1.Add XML documentation comments describing interface purpose and method behaviors

[x] 2. Create MCommunityApiClient Service Class
   [x] 2.Create `Services/MCommunityApiClient.cs` implementing `IMCommunityApiClient`
   [x] 2.Add private fields: `_httpClient`, `_logger`, `_options`
   [x] 2.Add constructor with dependency injection: `HttpClient`, `ILogger<MCommunityApiClient>`, `IOptions<MCommunityApiOptions>`
   [x] 2.Add private fields for token caching: `_accessToken`, `_refreshToken`, `_tokenExpiration`, `_currentAppId`
   [x] 2.Add thread-safety lock object for token operations

[x] 3. Implement Authentication Methods
   [x] 3.Create private `GetAccessTokenAsync(string appId, string password)` method
   [x] 3.Build TokenRequest object with username (appId) and password
   [x] 3.Serialize to JSON and POST to `/token/` endpoint
   [x] 3.Deserialize TokenResponse and cache tokens with expiration time
   [x] 3.Log authentication success/failure
   [x] 3.Handle HttpRequestException for 401 errors

[x] 4. Implement Token Refresh Method
   [x] 4.Create private `RefreshAccessTokenAsync()` method
   [x] 4.Build RefreshTokenRequest with cached refresh token
   [x] 4.POST to `/token/refresh/` endpoint
   [x] 4.Update cached access token and expiration
   [x] 4.Log refresh success/failure
   [x] 4.Handle errors and fall back to new token request if refresh fails

[x] 5. Implement Token Management Logic
   [x] 5.Create private `EnsureValidTokenAsync(string appId, string password)` method
   [x] 5.Check if current token is valid and for same appId
   [x] 5.If no token or expired (within 5 minutes of expiration), get new token
   [x] 5.If different appId than cached, clear cache and get new token
   [x] 5.Return valid access token
   [x] 5.Add thread-safe locking around token operations

[x] 6. Implement Authenticated Request Helper
   [x] 6.Create private `CreateAuthenticatedRequestAsync(HttpMethod method, string endpoint, string appId, string password)` method
   [x] 6.Call `EnsureValidTokenAsync()` to get valid token
   [x] 6.Create HttpRequestMessage with method and full URL (BaseUrl + endpoint)
   [x] 6.Add Authorization header: `Bearer {token}`
   [x] 6.Set appropriate Content-Type and Accept headers
   [x] 6.Return configured HttpRequestMessage

[x] 7. Implement GetPersonAsync Method
   [x] 7.Validate uniqname parameter (not null/empty)
   [x] 7.Create authenticated GET request to `/people/{uniqname}/`
   [x] 7.Send request via HttpClient
   [x] 7.Handle 404 response (return null)
   [x] 7.Handle 401 response (throw UnauthorizedException)
   [x] 7.Handle 403 response (throw ForbiddenException)
   [x] 7.Deserialize successful response to PersonData
   [x] 7.Log operation with uniqname (success/failure)
   [x] 7.Return PersonData or null

[x] 8. Implement GetGroupAsync Method
   [x] 8.Validate groupname parameter (not null/empty)
   [x] 8.Create authenticated GET request to `/groups/{groupname}/`
   [x] 8.Send request via HttpClient
   [x] 8.Handle 404 response (return null)
   [x] 8.Handle 401 response (throw UnauthorizedException)
   [x] 8.Handle 403 response (throw ForbiddenException)
   [x] 8.Deserialize successful response to GroupData
   [x] 8.Log operation with groupname (success/failure)
   [x] 8.Return GroupData or null

[x] 9. Implement Error Handling and Logging
   [x] 9.Add try-catch blocks for HttpRequestException, JsonException, OperationCanceledException
   [x] 9.Log detailed errors with context (uniqname/groupname, HTTP status, error message)
   [x] 9.Wrap exceptions in meaningful custom exceptions where appropriate
   [x] 9.Never log passwords or full tokens (mask if necessary)
   [x] 9.Log timing information for performance monitoring (optional)

[x] 10. Configure HTTP Client in Program.cs
    10.1. Register MCommunityApiClient as scoped service
    10.2. Configure HttpClient with IHttpClientFactory
    10.3. Set base address from configuration
    10.4. Configure timeout (30 seconds default)
    10.5. Add appropriate default request headers

[x] 11. Add XML Documentation
    11.1. Add comprehensive XML comments to all public methods
    11.2. Document parameters, return values, and exceptions
    11.3. Add usage examples in XML comments
    11.4. Document thread-safety considerations

[x] 12. Test Service Compilation and Registration
    12.1. Run `dotnet build` to verify service compiles
    12.2. Verify dependency injection registration in Program.cs
    12.3. Add logging configuration for `MCommunityWeb.Services` namespace
    12.4. Review any compiler warnings

## Completion Notes:

Task 3 completed on November 19, 2025. MCommunityApiClient service fully implemented:
- IMCommunityApiClient interface created with GetPersonAsync and GetGroupAsync method signatures
- MCommunityApiClient service class implements interface with HttpClient, ILogger, IOptions dependencies
- Token caching implemented with _accessToken, _refreshToken, _tokenExpiration, _currentAppId fields and thread-safety lock
- GetAccessTokenAsync authentication method implemented with proper error handling for 401 unauthorized
- Token management logic in EnsureValidTokenAsync checks token validity and app ID changes
- CreateAuthenticatedRequestAsync helper creates requests with Bearer token authorization
- GetPersonAsync implemented with 404, 401, 403 error handling and PersonData deserialization
- GetGroupAsync implemented with 404, 401, 403 error handling and GroupData deserialization
- Comprehensive error handling for HttpRequestException, JsonException with detailed logging
- HttpClient configured in Program.cs as scoped service with IHttpClientFactory
- Timeout configured from options (30 seconds default)
- XML documentation added to all public methods
- Never logs passwords or full tokens (security consideration met)
- Service compiles and is properly registered

