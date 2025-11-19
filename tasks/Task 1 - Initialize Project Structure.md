# Task 1 - Initialize Project Structure

Create the .NET Core MVC project structure with all necessary folders, configuration files, and dependencies. This establishes the foundation for the MCommunity Lookup web application.

## Status: Pending

## Dependencies: None

## Steps to Complete:

1. Create .NET 8.0 MVC Web Application
   1.1. Run `dotnet new mvc -n MCommunityWeb -f net8.0` in the projects/demo directory
   1.2. Verify project creation and structure
   1.3. Open solution in Visual Studio or VS Code

2. Configure Project Structure
   2.1. Create `Models/ApiModels/` directory for MCommunity API models
   2.2. Create `Models/ViewModels/` directory for view models
   2.3. Create `Services/` directory for business logic
   2.4. Create `Services/Interfaces/` directory for service interfaces
   2.5. Verify `wwwroot/css/`, `wwwroot/js/`, and `wwwroot/lib/` directories exist

3. Install Required NuGet Packages
   3.1. Verify `Microsoft.Extensions.Http` is available (included in .NET 8)
   3.2. Verify `System.Text.Json` is available (included in .NET 8)
   3.3. Install `Microsoft.Extensions.Logging.Debug` if not present
   3.4. Install `Microsoft.AspNetCore.Mvc.NewtonsoftJson` (optional, if needed for compatibility)

4. Configure appsettings.json
   4.1. Add `MCommunityApi` configuration section with `BaseUrl`, `TokenExpirationMinutes`, `RequestTimeoutSeconds`
   4.2. Configure logging levels for `Default`, `Microsoft.AspNetCore`, and `MCommunityWeb.Services`
   4.3. Set `AllowedHosts` to `*`
   4.4. Add warning comment about not storing credentials in configuration files

5. Update Program.cs for Dependency Injection
   5.1. Add `IHttpClientFactory` registration
   5.2. Configure services for `MCommunityApiClient` (to be created later)
   5.3. Add configuration binding for `MCommunityApiOptions`
   5.4. Configure HTTPS redirection and HSTS
   5.5. Add appropriate middleware pipeline configuration

6. Create Project Documentation Reference
   6.1. Add README.md in project root with link to `docs/DOCUMENTATION-MCOMMUNITY-LOOKUP.md`
   6.2. Add development setup instructions
   6.3. Add quick start guide

7. Initialize Git (if not already done)
   7.1. Ensure `.gitignore` includes typical .NET patterns
   7.2. Verify `bin/`, `obj/`, `*.user`, and `appsettings.Development.json` are ignored
   7.3. Add `*.Development.json` to gitignore to protect local credentials

8. Verify Project Builds
   8.1. Run `dotnet build` to verify project compiles
   8.2. Run `dotnet run` to verify application starts
   8.3. Access `https://localhost:5001` to verify default page loads
   8.4. Stop the application

## Completion Notes:

