# Task 2 - Implement API Models and Data Structures

Create all C# model classes for MCommunity API requests and responses, including authentication models, person data, group data, and view models for input validation.

## Status: Pending

## Dependencies: Task 1 - Initialize Project Structure

## Steps to Complete:

1. Create Authentication Models
   1.1. Create `Models/ApiModels/TokenRequest.cs` with `Username` and `Password` properties
   1.2. Create `Models/ApiModels/TokenResponse.cs` with `Access` and `Refresh` properties
   1.3. Create `Models/ApiModels/RefreshTokenRequest.cs` with `Refresh` property
   1.4. Create `Models/ApiModels/RefreshTokenResponse.cs` with `Access` property
   1.5. Add `[JsonPropertyName]` attributes matching MCommunity API field names
   1.6. Add XML documentation comments for all properties

2. Create Person Data Model
   2.1. Create `Models/ApiModels/PersonData.cs`
   2.2. Add `entry_dn` property (use JsonPropertyName "entry_dn" mapping to `Dn`)
   2.3. Add `uid` property for uniqname
   2.4. Add `displayName`, `givenName`, `surname` properties
   2.5. Add `cn` property as `List<string>` (array of common names)
   2.6. Add `mail` property as `List<string>` (array of emails)
   2.7. Add `telephoneNumber` property as `List<string>` (array of phone numbers)
   2.8. Add `umichTitle` property as `List<string>` (array of titles)
   2.9. Add `ou` property as `List<string>` (array of organizational units)
   2.10. Add `umichInstRoles` property as `List<string>` (affiliations - note correct field name)
   2.11. Add `groupMembership` property as `List<string>` (array of group DNs)
   2.12. Add XML documentation comments with notes about array properties

3. Create Group Data Model
   3.1. Create `Models/ApiModels/GroupData.cs`
   3.2. Add `dn` property for distinguished name
   3.3. Add `cn` property as `List<string>` (array of group names)
   3.4. Add `umichGroupEmail` property (local part of email)
   3.5. Add `owner` property as `List<string>` (array of owner DNs)
   3.6. Add `member` property as `List<string>` (array of member DNs)
   3.7. Add `umichDescription` property
   3.8. Add `modifyTimestamp` and `createTimestamp` properties
   3.9. Add XML documentation comments

4. Create Search Request Models
   4.1. Create `Models/ApiModels/PeopleSearchRequest.cs` (for future enhancements)
   4.2. Add `SearchParts`, `LogicalOperator`, `Attributes`, `NumEntries` properties
   4.3. Create nested `SearchPart` class with `Attribute`, `Value`, `SearchType`
   4.4. Add appropriate JsonPropertyName attributes
   4.5. Add XML documentation comments

5. Create View Models for Input Validation
   5.1. Create `Models/ViewModels/LookupRequestViewModel.cs`
   5.2. Add `SearchTerm` property with validation attributes:
       - `[Required]`
       - `[RegularExpression]` for combined uniqname/group pattern
   5.3. Add `ApplicationId` property with `[Required]` attribute
   5.4. Add `Password` property with `[Required]` attribute
   5.5. Add XML documentation comments explaining validation rules

6. Create Response Wrapper Models
   6.1. Create `Models/ApiModels/LookupResponse.cs` for standardized API responses
   6.2. Add `Success` (bool), `Data` (object), `Error` (string), `Type` (string) properties
   6.3. Add `ErrorCode` (string) and `Timestamp` (DateTime) properties
   6.4. Add static factory methods: `SuccessResult()`, `ErrorResult()`, `NotFoundResult()`
   6.5. Add XML documentation comments

7. Create Helper Models
   7.1. Create `Models/ApiModels/MCommunityApiOptions.cs` for configuration binding
   7.2. Add `BaseUrl`, `TokenExpirationMinutes`, `RequestTimeoutSeconds` properties
   7.3. Add default values and validation logic
   7.4. Add XML documentation comments

8. Add DN Helper Methods
   8.1. Create `Helpers/MCommunityHelpers.cs` static class
   8.2. Add `GetPersonDn(string uniqname)` method
   8.3. Add `GetGroupDn(string groupname)` method
   8.4. Add `GetPersonDns(IEnumerable<string> uniqnames)` method
   8.5. Add `ExtractUniqnameFromDn(string dn)` method
   8.6. Add `ExtractGroupnameFromDn(string dn)` method
   8.7. Add XML documentation comments with DN format examples

9. Verify Models Compile
   9.1. Run `dotnet build` to verify all models compile without errors
   9.2. Review any warnings and address as needed
   9.3. Ensure all required using statements are present

## Completion Notes:

