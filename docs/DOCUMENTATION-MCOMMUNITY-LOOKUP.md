# MCommunity Lookup Web Application - Documentation

## Project Overview

The MCommunity Lookup Web Application is a single-page .NET Core MVC web application that provides a unified search interface for looking up University of Michigan identities (people) and groups via the MCommunity API.

**Key Features:**
- Single unified search field that auto-detects input type (uniqname or group)
- Dynamic results display without page reload
- Client-side API credential management via browser localStorage
- Real-time validation and error handling
- Responsive Bootstrap 5 UI

**Created:** November 19, 2025

## Business Requirements

### User Stories

1. **As a user**, I want to enter a uniqname or group name in a single search field and see the results immediately without page reload.

2. **As a user**, I want the application to automatically detect whether I'm searching for a person or a group based on the input format.

3. **As a user**, I want to configure and store my MCommunity API credentials securely in my browser so I don't have to enter them repeatedly.

4. **As a user**, I want to see comprehensive information about people including their name, email, phone, title, department, and affiliations.

5. **As a user**, I want to see group information including members, owners, and group email address.

6. **As a user**, I want clear error messages when a person/group is not found or when my API credentials are invalid.

### Functional Requirements

1. **Input Validation**
   - Uniqname: 3-8 alphanumeric characters only
   - Group name: 9-62 characters (alphanumeric, dash, underscore allowed)
   - Real-time validation feedback
   - Enter key or button click triggers search

2. **API Credential Management**
   - Settings button opens modal dialog
   - Fields for Application ID and Password
   - Credentials stored in browser localStorage
   - Credentials passed to backend with each API request
   - Clear indication when credentials are not configured

3. **Search Functionality**
   - Auto-detect input type based on length and format
   - Single endpoint handles both person and group lookups
   - Asynchronous API calls with loading indicators
   - Results display dynamically in-page

4. **Person Results Display**
   - Display Name
   - Email addresses (can be multiple)
   - Phone numbers (can be multiple)
   - Titles (can be multiple)
   - Department/Organizational Units
   - Institutional Roles/Affiliations
   - Distinguished Name (DN)

5. **Group Results Display**
   - Group name(s)
   - Group email address
   - Description
   - List of members (with DNs)
   - List of owners (with DNs)
   - Creation and modification timestamps
   - Distinguished Name (DN)

6. **Error Handling**
   - 401: Invalid API credentials
   - 404: Person/group not found
   - 403: Insufficient permissions
   - Network errors
   - Invalid input format
   - User-friendly error messages

## Technical Architecture

### Technology Stack

- **.NET 8.0** (LTS) - Framework
- **ASP.NET Core MVC** - Web framework
- **C# 12** - Programming language
- **System.Text.Json** - JSON serialization
- **IHttpClientFactory** - HTTP client management
- **Bootstrap 5** - UI framework
- **jQuery** or **Vanilla JavaScript** - Client-side interactions
- **localStorage Web API** - Client-side credential storage

### Project Structure

```
MCommunityWeb/
├── Controllers/
│   ├── HomeController.cs          # Serves main page
│   └── ApiController.cs            # Backend API endpoint
├── Models/
│   ├── ViewModels/
│   │   └── LookupRequestViewModel.cs  # Input validation model
│   └── ApiModels/
│       ├── PersonData.cs           # Person API response
│       ├── GroupData.cs            # Group API response
│       ├── TokenRequest.cs         # Auth token request
│       ├── TokenResponse.cs        # Auth token response
│       └── RefreshTokenRequest.cs  # Token refresh request
├── Services/
│   ├── Interfaces/
│   │   └── IMCommunityApiClient.cs
│   └── MCommunityApiClient.cs      # API client implementation
├── Views/
│   ├── Home/
│   │   └── Index.cshtml            # Main single-page UI
│   └── Shared/
│       ├── _Layout.cshtml           # Layout template
│       └── Error.cshtml             # Error page
├── wwwroot/
│   ├── css/
│   │   └── site.css                # Custom styles
│   ├── js/
│   │   ├── mcommunity-lookup.js   # Search and display logic
│   │   └── settings-modal.js       # Credential management
│   └── lib/                         # Client libraries (Bootstrap, jQuery)
├── appsettings.json                 # App configuration (no credentials)
├── appsettings.Development.json     # Development settings
├── Program.cs                       # Application entry point
└── MCommunityWeb.csproj            # Project file
```

### Architecture Patterns

#### 1. **Service Layer Pattern**
- `MCommunityApiClient` encapsulates all MCommunity API interactions
- Registered as scoped service via dependency injection
- Handles authentication, token management, and API calls
- Implements `IMCommunityApiClient` interface for testability

#### 2. **Repository Pattern** (Light Implementation)
- `MCommunityApiClient` acts as repository for external data
- Abstracts API details from controllers
- Provides clean, typed methods for data access

#### 3. **Options Pattern**
- MCommunity API configuration via `IOptions<MCommunityApiOptions>`
- Allows runtime credential injection (passed from client)
- Separates configuration from code

#### 4. **MVC Pattern**
- Controllers handle HTTP requests and orchestrate responses
- Models represent data structures and validation rules
- Views render UI using Razor syntax

#### 5. **API Gateway Pattern** (Simplified)
- Backend API controller acts as gateway to MCommunity API
- Validates input before forwarding to external API
- Transforms external API responses for frontend consumption
- Centralizes error handling

### Data Flow

```
┌─────────────┐
│   Browser   │
│  (Client)   │
└──────┬──────┘
       │
       │ 1. User enters search term
       │ 2. Click search/press Enter
       │
       ▼
┌─────────────────────┐
│   JavaScript        │
│   - Validate input  │
│   - Get credentials │
│     from localStorage│
└──────┬──────────────┘
       │
       │ 3. POST /api/lookup
       │    { searchTerm, credentials }
       │
       ▼
┌─────────────────────┐
│  ApiController      │
│  - Validate input   │
│  - Extract creds    │
│  - Call service     │
└──────┬──────────────┘
       │
       │ 4. Call GetPersonAsync() or GetGroupAsync()
       │
       ▼
┌──────────────────────┐
│ MCommunityApiClient  │
│ - Authenticate       │
│ - Get/refresh token  │
│ - Call MCommunity API│
└──────┬───────────────┘
       │
       │ 5. GET https://mcommunity.umich.edu/api/people/{uniqname}
       │    or GET .../api/groups/{groupname}
       │    Authorization: Bearer {token}
       │
       ▼
┌─────────────────────┐
│  MCommunity API     │
│  (External)         │
└──────┬──────────────┘
       │
       │ 6. Return PersonData or GroupData JSON
       │
       ▼
┌──────────────────────┐
│ MCommunityApiClient  │
│ - Deserialize JSON   │
│ - Return typed object│
└──────┬───────────────┘
       │
       │ 7. Return result or error
       │
       ▼
┌─────────────────────┐
│  ApiController      │
│  - Format response  │
│  - Handle errors    │
└──────┬──────────────┘
       │
       │ 8. JSON response
       │    { success, data, error }
       │
       ▼
┌─────────────────────┐
│   JavaScript        │
│   - Parse response  │
│   - Render results  │
│   - Display errors  │
└──────┬──────────────┘
       │
       │ 9. Update DOM with results
       │
       ▼
┌─────────────┐
│   Browser   │
│  (Display)  │
└─────────────┘
```

### Key Components

#### MCommunityApiClient Service

**Responsibilities:**
- Authenticate with MCommunity API using provided credentials
- Manage access and refresh tokens with 55-minute expiration
- Execute GET requests for person and group lookups
- Deserialize JSON responses into strongly-typed models
- Handle HTTP errors and translate to meaningful exceptions
- Log API interactions for debugging

**Key Methods:**
```csharp
Task<PersonData> GetPersonAsync(string uniqname, string appId, string password)
Task<GroupData> GetGroupAsync(string groupname, string appId, string password)
Task<string> EnsureValidTokenAsync(string appId, string password)
```

#### API Controller

**Responsibilities:**
- Accept POST requests with search term and credentials
- Validate input against regex patterns
- Determine lookup type (person vs. group) based on input
- Call appropriate MCommunityApiClient method
- Transform results into JSON response
- Catch and translate exceptions into error responses

**Endpoint:**
```
POST /api/lookup
Request: { searchTerm: string, applicationId: string, password: string }
Response: { success: bool, data: object, error: string, type: string }
```

#### Client-Side JavaScript

**Responsibilities:**
- Handle form submission and Enter key press
- Retrieve credentials from localStorage
- Validate input with regex before sending
- Display loading indicator during API call
- Dynamically render person or group results
- Display error messages with appropriate styling
- Manage settings modal for credential configuration

**Key Functions:**
```javascript
function performLookup(searchTerm)
function displayPersonResults(data)
function displayGroupResults(data)
function displayError(message)
function openSettingsModal()
function saveCredentials(appId, password)
function getCredentials()
```

### Input Validation Strategy

#### Client-Side (JavaScript)
- **Uniqname Pattern:** `/^[a-zA-Z0-9]{3,8}$/`
- **Group Pattern:** `/^[a-zA-Z0-9_-]{9,62}$/`
- Immediate feedback on input blur/change
- Prevent submission of invalid input
- Visual indicators (red border, error text)

#### Server-Side (C# DataAnnotations)
```csharp
[Required(ErrorMessage = "Search term is required")]
[RegularExpression(@"^[a-zA-Z0-9]{3,8}$|^[a-zA-Z0-9_-]{9,62}$",
    ErrorMessage = "Invalid format")]
public string SearchTerm { get; set; }
```

### Security Considerations

#### 1. **Credential Storage**
- **Current Approach:** Browser localStorage (client-side only)
- **Pros:** No server-side credential management, user controls their own creds
- **Cons:** Stored in plain text, accessible via JavaScript, vulnerable to XSS
- **Mitigation:** Clear warning to users about credential storage
- **Future Enhancement:** Server-side secure storage option

#### 2. **HTTPS Enforcement**
- All communication must use HTTPS
- Credentials transmitted in HTTPS request body/headers only
- Configure HSTS in production

#### 3. **Input Sanitization**
- Validate all input server-side regardless of client validation
- Use parameterized API calls (no string concatenation)
- Encode output when displaying user-provided data

#### 4. **Error Message Sanitization**
- Don't expose internal error details to client
- Log detailed errors server-side
- Return generic error messages to client

#### 5. **CORS Configuration**
- Restrict API endpoints to same-origin requests only
- Configure appropriate CORS policies if needed

### MCommunity API Integration Details

#### Authentication Flow

1. **Initial Token Request:**
   ```
   POST https://mcommunity.umich.edu/api/token/
   Body: { "username": "cn=...", "password": "..." }
   Response: { "access": "...", "refresh": "..." }
   ```

2. **Token Caching:**
   - Store access token, refresh token, and expiration time
   - Check expiration before each API call
   - Reuse valid tokens to minimize authentication requests

3. **Token Refresh (once):**
   ```
   POST https://mcommunity.umich.edu/api/token/refresh/
   Body: { "refresh": "..." }
   Response: { "access": "..." }
   ```

4. **New Token After Refresh Expires:**
   - Cannot refresh again after using refresh token
   - Must authenticate with credentials again

#### Person Lookup

**Endpoint:** `GET https://mcommunity.umich.edu/api/people/{uniqname}/`

**Headers:**
```
Authorization: Bearer {access_token}
```

**Response Fields (Key):**
- `entry_dn` - Distinguished Name (NOT `dn`)
- `uid` - Uniqname
- `displayName` - Full display name
- `givenName` - First name
- `surname` - Last name (NOT `sn`)
- `mail` - **Array** of email addresses
- `telephoneNumber` - **Array** of phone numbers
- `umichTitle` - **Array** of job titles
- `ou` - **Array** of organizational units
- `umichInstRoles` - **Array** of affiliations (NOT `umichAffiliation`)
- `groupMembership` - **Array** of group DNs

**Privacy Note:** Fields may be null/missing based on privacy settings and Application ID permissions.

#### Group Lookup

**Endpoint:** `GET https://mcommunity.umich.edu/api/groups/{groupname}/`

**Headers:**
```
Authorization: Bearer {access_token}
```

**Response Fields:**
- `dn` - Distinguished Name
- `cn` - **Array** of common names
- `umichGroupEmail` - Group email local part (becomes email@umich.edu)
- `owner` - **Array** of owner DNs
- `member` - **Array** of member DNs
- `umichDescription` - Group description
- `modifyTimestamp` - Last modification timestamp
- `createTimestamp` - Creation timestamp

**Permission Note:** Application ID must be group owner to access group data.

### Error Handling Strategy

#### Error Types and Responses

| Error Scenario | HTTP Status | User Message | Logging |
|---------------|-------------|--------------|---------|
| Invalid credentials | 401 | "Invalid API credentials. Please check your settings." | Log warning with app ID |
| Person/group not found | 404 | "No results found for '{searchTerm}'." | Log info |
| Insufficient permissions | 403 | "You don't have permission to view this information." | Log warning |
| Invalid input format | 400 | "Invalid format. Uniqname: 3-8 alphanumeric, Group: 9-62 chars." | Log info |
| Network error | 500 | "Unable to connect to MCommunity API. Please try again." | Log error with details |
| Timeout | 408 | "Request timed out. Please try again." | Log warning |
| Rate limiting | 429 | "Too many requests. Please wait a moment." | Log warning |
| Unknown error | 500 | "An unexpected error occurred. Please try again." | Log error with stack trace |

#### Error Response Format (API)

```json
{
  "success": false,
  "error": "User-friendly error message",
  "errorCode": "NOT_FOUND",
  "timestamp": "2025-11-19T10:30:00Z"
}
```

### UI/UX Design

#### Main Page Layout

```
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│   MCommunity Lookup                          [⚙️ Settings]  │
│                                                             │
│   ┌─────────────────────────────────────────────────────┐ │
│   │ Enter uniqname or group name...          [Search 🔍]│ │
│   └─────────────────────────────────────────────────────┘ │
│                                                             │
│   ─────────────────────────────────────────────────────── │
│                                                             │
│   [Results Display Area - Initially Empty]                 │
│                                                             │
│   Person Results:                                           │
│   ┌─────────────────────────────────────────────────────┐ │
│   │ 📧 Name: John Doe                                    │ │
│   │ 📧 Email: jdoe@umich.edu                             │ │
│   │ 📞 Phone: 734-555-1234                               │ │
│   │ 💼 Title: Software Engineer                          │ │
│   │ 🏢 Department: Information Technology                │ │
│   │ 🎓 Affiliations: Staff, Alumni                       │ │
│   └─────────────────────────────────────────────────────┘ │
│                                                             │
│   Group Results:                                            │
│   ┌─────────────────────────────────────────────────────┐ │
│   │ 👥 Group: project-team                               │ │
│   │ 📧 Email: projectteam@umich.edu                      │ │
│   │ 📝 Description: Project collaboration group          │ │
│   │ 👤 Owners (2): bjensen, jsmith                       │ │
│   │ 👥 Members (15): [Show Members]                      │ │
│   └─────────────────────────────────────────────────────┘ │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

#### Settings Modal

```
┌─────────────────────────────────────────────┐
│  MCommunity API Settings               [✖️] │
├─────────────────────────────────────────────┤
│                                             │
│  Application ID:                            │
│  ┌─────────────────────────────────────┐   │
│  │ cn=mcapi-dept-usage,ou=apiusers,... │   │
│  └─────────────────────────────────────┘   │
│                                             │
│  Password:                                  │
│  ┌─────────────────────────────────────┐   │
│  │ ••••••••••••••••••                  │   │
│  └─────────────────────────────────────┘   │
│                                             │
│  ⚠️  Credentials are stored in your browser │
│     and sent to the server with each       │
│     request. Keep them secure.             │
│                                             │
│        [Cancel]           [Save]            │
└─────────────────────────────────────────────┘
```

### Performance Considerations

1. **Token Caching:**
   - Cache tokens for 55 minutes to minimize auth requests
   - Use single token instance across concurrent requests
   - Implement thread-safe token refresh

2. **HTTP Client Reuse:**
   - Use `IHttpClientFactory` for proper HttpClient lifecycle
   - Avoid socket exhaustion
   - Configure appropriate timeouts (30 seconds)

3. **Async/Await:**
   - All I/O operations use async/await
   - Prevents thread blocking
   - Improves scalability

4. **Client-Side Optimization:**
   - Debounce search input (300ms delay)
   - Prevent duplicate concurrent requests
   - Show loading indicators during API calls
   - Cache recent search results (optional enhancement)

5. **Minimal Attribute Retrieval:**
   - Person lookup returns all visible attributes by default
   - Group lookup returns standard group data
   - Consider filtering if performance issues arise

### Testing Strategy

#### Unit Tests
- `MCommunityApiClient` authentication logic
- Token expiration and refresh logic
- Input validation logic
- DN helper methods
- Error handling and exception mapping

#### Integration Tests
- End-to-end person lookup flow
- End-to-end group lookup flow
- Authentication failure handling
- 404 handling
- Token refresh scenarios

#### Manual Testing Checklist
- [ ] Search for valid uniqname
- [ ] Search for invalid uniqname (404)
- [ ] Search for valid group
- [ ] Search for invalid group (404)
- [ ] Test with invalid credentials (401)
- [ ] Test with missing credentials
- [ ] Test input validation (too short, too long, invalid chars)
- [ ] Test Enter key submission
- [ ] Test button click submission
- [ ] Open settings modal
- [ ] Save credentials to localStorage
- [ ] Verify credentials persist after page reload
- [ ] Test error display for various scenarios
- [ ] Test display of person with multiple emails/phones/titles
- [ ] Test display of group with many members
- [ ] Test network error handling (disconnect network)

### Logging Strategy

#### Log Levels

- **Debug:** Token refresh operations, detailed API call parameters
- **Information:** API call start/completion, successful lookups, cache hits
- **Warning:** 404 not found, 403 permission denied, rate limiting
- **Error:** Authentication failures, network errors, unexpected exceptions
- **Critical:** Service unavailable, configuration errors

#### Logged Events

```csharp
// Authentication
_logger.LogInformation("Authenticating with MCommunity API for app ID: {AppId}", appId);
_logger.LogWarning("Authentication failed for app ID: {AppId}", appId);

// Lookups
_logger.LogInformation("Looking up person: {Uniqname}", uniqname);
_logger.LogInformation("Person found: {Uniqname}, DisplayName: {DisplayName}", uid, displayName);
_logger.LogWarning("Person not found: {Uniqname}", uniqname);

// Errors
_logger.LogError(ex, "HTTP error retrieving person: {Uniqname}", uniqname);
_logger.LogError(ex, "Unexpected error in MCommunity API client");
```

#### Sensitive Data
- **Never log:** Passwords, tokens, full credentials
- **Hash/Mask:** Application IDs (log first/last 4 chars only)
- **Safe to log:** Uniqnames, group names, search terms, HTTP status codes

### Configuration

#### appsettings.json

```json
{
  "MCommunityApi": {
    "BaseUrl": "https://mcommunity.umich.edu/api",
    "TokenExpirationMinutes": 55,
    "RequestTimeoutSeconds": 30
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "MCommunityWeb.Services": "Debug"
    }
  },
  "AllowedHosts": "*"
}
```

**Note:** No credentials in configuration files. All credentials provided by client at runtime.

### Deployment Considerations

#### Development Environment
- Use Visual Studio 2022 or VS Code with C# extensions
- .NET 8.0 SDK installed
- Configure user secrets for test credentials (optional)
- Use IIS Express or Kestrel for local development

#### Production Environment
- Deploy to IIS, Azure App Service, or Docker container
- Enable HTTPS/TLS (required)
- Configure HSTS headers
- Set appropriate CORS policies
- Enable logging to Application Insights or similar
- Configure health checks
- Set reasonable request size limits

#### Environment Variables (Optional)
- `ASPNETCORE_ENVIRONMENT`: Development, Staging, Production
- `MCOMMUNITY_API_BASEURL`: Override base URL if needed

### Future Enhancements

1. **Server-Side Credential Storage:**
   - User authentication with ASP.NET Identity
   - Store encrypted credentials in database
   - Associate credentials with user accounts

2. **Search History:**
   - Store recent searches in localStorage or database
   - Quick access to frequently searched items
   - Clear history option

3. **Bulk Lookup:**
   - Upload CSV of uniqnames/groups
   - Batch processing with progress indicator
   - Export results to CSV/Excel

4. **Advanced Search:**
   - Use `/people/find/` endpoint for attribute-based search
   - Search by name, department, email, etc.
   - Multiple search criteria with AND/OR logic

5. **Group Management:**
   - Add/remove members from groups
   - Create new groups
   - Update group properties
   - Requires additional authorization

6. **Caching:**
   - Cache lookup results for configurable duration
   - Reduce API calls for frequently accessed data
   - Implement cache invalidation strategy

7. **Export Functionality:**
   - Export person/group data to PDF
   - Generate vCard for person
   - Download group member list

8. **Accessibility Improvements:**
   - ARIA labels for screen readers
   - Keyboard navigation
   - High contrast mode support
   - WCAG 2.1 AA compliance

## API Reference

For complete MCommunity API documentation, see:
- **Local Documentation:** [`docs/api/api-mcommunity.md`](../api/api-mcommunity.md)
- **Swagger API:** https://mcommunity.umich.edu/api/doc/schema/swagger-ui/
- **ITS Documentation:** https://documentation.its.umich.edu/node/3955
- **Code Examples:** https://github.com/umich-iam/iam-api-examples

## Glossary

- **Uniqname:** Unique username identifier at University of Michigan (3-8 alphanumeric characters)
- **DN (Distinguished Name):** LDAP-style unique identifier (e.g., `uid=bjensen,ou=People,dc=umich,dc=edu`)
- **Application ID:** Credential used to authenticate with MCommunity API (format: `cn=mcapi-dept-usage,ou=apiusers,o=services`)
- **MCommunity:** University of Michigan's directory service (LDAP-based)
- **Bearer Token:** JWT-style access token used for API authentication
- **Group:** Collection of people in MCommunity (format: `cn=groupname,ou=User Groups,ou=Groups,dc=umich,dc=edu`)
- **Institutional Roles:** Affiliations like Student, Faculty, Staff, Alumni, etc.

## References

- [ASP.NET Core MVC Documentation](https://docs.microsoft.com/en-us/aspnet/core/mvc/)
- [IHttpClientFactory Documentation](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
- [System.Text.Json Documentation](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.0/)
- [LDAP v3 RFC](https://www.rfc-editor.org/rfc/rfc4510)
