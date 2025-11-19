# MCommunity Lookup Web Application

A single-page .NET Core MVC web application for looking up University of Michigan identities (people) and groups via the MCommunity API.

## Overview

This application provides a unified search interface where users can:
- Search for people by uniqname (3-8 alphanumeric characters)
- Search for groups by group name (9-62 characters with alphanumeric, dash, underscore)
- View detailed information about people and groups
- Configure MCommunity API credentials via browser settings

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- A modern web browser (Chrome, Firefox, Edge, Safari)
- MCommunity API credentials (Application ID and Password)
  - Contact [ITS Service Center](https://its.umich.edu/help) to obtain credentials

## Getting Started

### 1. Clone or Download

If this is your first time setting up the project, you already have the source code.

### 2. Build the Project

```powershell
cd MCommunityWeb
dotnet build
```

### 3. Run the Application

```powershell
dotnet run
```

The application will start and display URLs like:
```
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
```

### 4. Open in Browser

Navigate to `https://localhost:5001` in your web browser.

### 5. Configure API Credentials

1. Click the **Settings** button (⚙️) in the top-right corner
2. Enter your MCommunity API Application ID
   - Format: `cn=mcapi-dept-usage,ou=apiusers,o=services`
3. Enter your MCommunity API Password
4. Click **Save**

**Important:** Credentials are stored in your browser's localStorage. They are sent to the backend with each API request but are NOT stored on the server.

### 6. Search for People or Groups

- **Search for a person:** Enter a uniqname (3-8 characters, e.g., `bjensen`)
- **Search for a group:** Enter a group name (9-62 characters, e.g., `project-team-2024`)
- Press **Enter** or click the **Search** button

## Project Structure

```
MCommunityWeb/
├── Controllers/           # MVC controllers
│   ├── HomeController.cs
│   └── ApiController.cs
├── Models/
│   ├── ApiModels/        # MCommunity API request/response models
│   └── ViewModels/       # View models for input validation
├── Services/             # Business logic and API client
│   ├── Interfaces/
│   └── MCommunityApiClient.cs
├── Helpers/              # Utility classes
├── Views/                # Razor views
│   ├── Home/
│   └── Shared/
├── wwwroot/              # Static files
│   ├── css/
│   ├── js/
│   └── lib/
├── appsettings.json      # Application configuration
└── Program.cs            # Application entry point
```

## Configuration

### appsettings.json

The application configuration is in `appsettings.json`:

```json
{
  "MCommunityApi": {
    "BaseUrl": "https://mcommunity.umich.edu/api",
    "TokenExpirationMinutes": 55,
    "RequestTimeoutSeconds": 30
  }
}
```

**Note:** Do NOT store API credentials in configuration files. Credentials are provided by users through the browser interface.

## Development

### Build and Run in Development Mode

```powershell
dotnet run --environment Development
```

### Watch Mode (Auto-rebuild on Changes)

```powershell
dotnet watch run
```

### Run Tests (when available)

```powershell
dotnet test
```

## Usage Examples

### Search for a Person

1. Enter a valid uniqname (e.g., `bjensen`)
2. Results display:
   - Name, email(s), phone(s)
   - Job title(s), department(s)
   - Institutional roles/affiliations

### Search for a Group

1. Enter a valid group name (e.g., `iamGroupsWSTest1`)
2. Results display:
   - Group name and email
   - Description
   - Owners and members

## Troubleshooting

### "Invalid API credentials" Error

- Verify your Application ID and Password are correct
- Check with ITS Service Center if credentials have expired
- Click the Settings button to update credentials

### "No results found" Error

- Verify the uniqname or group name is spelled correctly
- Ensure the person/group exists in MCommunity
- Check if you have permission to view the information

### "Insufficient permissions" Error

- Your Application ID may not have access to the requested data
- For groups, your Application ID must be a group owner
- Contact ITS Service Center to request additional permissions

### Network Errors

- Verify you have internet connectivity
- Check if the MCommunity API is accessible
- Ensure HTTPS certificates are valid

## Documentation

For complete project documentation, see:

- **Technical Documentation:** [`../docs/DOCUMENTATION-MCOMMUNITY-LOOKUP.md`](../docs/DOCUMENTATION-MCOMMUNITY-LOOKUP.md)
- **MCommunity API Documentation:** [`../docs/api/api-mcommunity.md`](../docs/api/api-mcommunity.md)
- **Task Breakdown:** [`../tasks/`](../tasks/)
- **Changelog:** [`../docs/CHANGELOG.md`](../docs/CHANGELOG.md)

## Security Considerations

⚠️ **Important Security Notes:**

1. **Credential Storage:** API credentials are stored in your browser's localStorage in plain text. Anyone with access to your computer can potentially retrieve them.

2. **HTTPS Required:** Always use HTTPS in production to protect credentials in transit.

3. **Shared Computers:** If using a shared computer, consider clearing your credentials after use:
   - Open browser Developer Tools (F12)
   - Go to Application > Local Storage
   - Clear `mcommunity_api_credentials`

4. **Credential Scope:** Only use credentials provided by your organization. Do not share credentials with others.

## Obtaining MCommunity API Credentials

To obtain Application ID credentials:

1. Contact the [ITS Service Center](https://its.umich.edu/help)
2. Provide:
   - Your department or team name
   - Short name of your application
   - Two or more contacts (uniqname/email and phone)
   - Types of objects you'll work with (users, groups, or both)
   - Business case for special data access (if needed)

For more information, see [MCommunity API Documentation](https://documentation.its.umich.edu/node/3955).

## Support

For issues or questions:

- **Technical Issues:** Review documentation in `docs/` folder
- **API Issues:** Contact [ITS Service Center](https://its.umich.edu/help)
- **MCommunity API:** See [Swagger Documentation](https://mcommunity.umich.edu/api/doc/schema/swagger-ui/)

## License

This project is for internal use at the University of Michigan.

## Version

**Current Version:** 1.0.0 (In Development)

See [`../docs/CHANGELOG.md`](../docs/CHANGELOG.md) for version history and changes.
