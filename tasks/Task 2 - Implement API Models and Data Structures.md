# Task 2 - Implement API Models and Data Structures

Create all C# model classes for MCommunity API requests and responses, including authentication models, person data, group data, and view models for input validation.

## Status: Completed

## Dependencies: Task 1 - Initialize Project Structure

## Steps to Complete:

[x] 1. Create Authentication Models
   [x] 1.1. Create `Models/ApiModels/TokenRequest.cs` with `Username` and `Password` properties
   [x] 1.2. Create `Models/ApiModels/TokenResponse.cs` with `Access` and `Refresh` properties
   [x] 1.3. Create `Models/ApiModels/RefreshTokenRequest.cs` with `Refresh` property
   [x] 1.4. Create `Models/ApiModels/RefreshTokenResponse.cs` with `Access` property
   [x] 1.5. Add `[JsonPropertyName]` attributes matching MCommunity API field names
   [x] 1.6. Add XML documentation comments for all properties

[x] 2. Create Person Data Model
   [x] 2.1. Create `Models/ApiModels/PersonData.cs`
   [x] 2.2. Add `entry_dn` property (use JsonPropertyName "entry_dn" mapping to `Dn`)
   [x] 2.3. Add `uid` property for uniqname
   [x] 2.4. Add `displayName`, `givenName`, `surname` properties
   [x] 2.5. Add `cn` property as `List<string>` (array of common names)
   [x] 2.6. Add `mail` property as `List<string>` (array of emails)
   [x] 2.7. Add `telephoneNumber` property as `List<string>` (array of phone numbers)
   [x] 2.8. Add `umichTitle` property as `List<string>` (array of titles)
   [x] 2.9. Add `ou` property as `List<string>` (array of organizational units)
   [x] 2.10. Add `umichInstRoles` property as `List<string>` (affiliations - note correct field name)
   [x] 2.11. Add `groupMembership` property as `List<string>` (array of group DNs)
   [x] 2.12. Add XML documentation comments with notes about array properties

[x] 3. Create Group Data Model
   [x] 3.1. Create `Models/ApiModels/GroupData.cs`
   [x] 3.2. Add `dn` property for distinguished name
   [x] 3.3. Add `cn` property as `List<string>` (array of group names)
   [x] 3.4. Add `umichGroupEmail` property (local part of email)
   [x] 3.5. Add `owner` property as `List<string>` (array of owner DNs)
   [x] 3.6. Add `member` property as `List<string>` (array of member DNs)
   [x] 3.7. Add `umichDescription` property
   [x] 3.8. Add `modifyTimestamp` and `createTimestamp` properties
   [x] 3.9. Add XML documentation comments

[x] 4. Create Search Request Models
   [x] 4.1. Create `Models/ApiModels/PeopleSearchRequest.cs` (for future enhancements)
   [x] 4.2. Add `SearchParts`, `LogicalOperator`, `Attributes`, `NumEntries` properties
   [x] 4.3. Create nested `SearchPart` class with `Attribute`, `Value`, `SearchType`
   [x] 4.4. Add appropriate JsonPropertyName attributes
   [x] 4.5. Add XML documentation comments

[x] 5. Create View Models for Input Validation
   [x] 5.1. Create `Models/ViewModels/LookupRequestViewModel.cs`
   [x] 5.2. Add `SearchTerm` property with validation attributes:
       - `[Required]`
       - `[RegularExpression]` for combined uniqname/group pattern
   [x] 5.3. Add `ApplicationId` property with `[Required]` attribute
   [x] 5.4. Add `Password` property with `[Required]` attribute
   [x] 5.5. Add XML documentation comments explaining validation rules

[x] 6. Create Response Wrapper Models
   [x] 6.1. Create `Models/ApiModels/LookupResponse.cs` for standardized API responses
   [x] 6.2. Add `Success` (bool), `Data` (object), `Error` (string), `Type` (string) properties
   [x] 6.3. Add `ErrorCode` (string) and `Timestamp` (DateTime) properties
   [x] 6.4. Add static factory methods: `SuccessResult()`, `ErrorResult()`, `NotFoundResult()`
   [x] 6.5. Add XML documentation comments

[x] 7. Create Helper Models
   [x] 7.1. Create `Models/ApiModels/MCommunityApiOptions.cs` for configuration binding
   [x] 7.2. Add `BaseUrl`, `TokenExpirationMinutes`, `RequestTimeoutSeconds` properties
   [x] 7.3. Add default values and validation logic
   [x] 7.4. Add XML documentation comments

[x] 8. Add DN Helper Methods
   [x] 8.1. Create `Helpers/MCommunityHelpers.cs` static class
   [x] 8.2. Add `GetPersonDn(string uniqname)` method
   [x] 8.3. Add `GetGroupDn(string groupname)` method
   [x] 8.4. Add `GetPersonDns(IEnumerable<string> uniqnames)` method
   [x] 8.5. Add `ExtractUniqnameFromDn(string dn)` method
   [x] 8.6. Add `ExtractGroupnameFromDn(string dn)` method
   [x] 8.7. Add XML documentation comments with DN format examples

[x] 9. Verify Models Compile
   [x] 9.1. Run `dotnet build` to verify all models compile without errors
   [x] 9.2. Review any warnings and address as needed
   [x] 9.3. Ensure all required using statements are present

## Completion Notes:

Task 2 completed on November 19, 2025. All API models and data structures implemented:
- Authentication models created: TokenRequest, TokenResponse, RefreshTokenRequest, RefreshTokenResponse with proper JsonPropertyName attributes
- PersonData model created with all fields including entry_dn, uid, displayName, givenName, surname, cn, mail, telephoneNumber, umichTitle, ou, umichInstRoles, groupMembership
- GroupData model created with dn, cn, umichGroupEmail, owner, member, umichDescription, modifyTimestamp, createTimestamp
- LookupRequestViewModel created with validation attributes for SearchTerm, ApplicationId, Password
- LookupResponse wrapper model created with Success, Data, Error, Type, ErrorCode, Timestamp properties and factory methods
- MCommunityApiOptions configuration model created
- MCommunityHelpers static class created with GetPersonDn, GetGroupDn, ExtractUniqnameFromDn, ExtractGroupnameFromDn, DetermineSearchType methods
- All models have XML documentation comments
- Project builds without errors

