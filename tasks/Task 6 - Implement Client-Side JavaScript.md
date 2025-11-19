# Task 6 - Implement Client-Side JavaScript

Create all client-side JavaScript functionality for handling search, API calls, credential management, and dynamic results display.

## Status: Pending

## Dependencies: Task 4 - Create API Controller and Backend Logic, Task 5 - Create Main UI View and Layout

## Steps to Complete:

1. Create Settings Management Script
   1.1. Create `wwwroot/js/settings-modal.js`
   1.2. Add function `openSettingsModal()` to show modal and load current credentials
   1.3. Add function `closeSettingsModal()` to hide modal
   1.4. Add function `saveCredentials()` to save Application ID and Password to localStorage
   1.5. Add function `getCredentials()` to retrieve credentials from localStorage
   1.6. Add function `hasCredentials()` to check if credentials exist
   1.7. Add event listener for settings button click
   1.8. Add event listener for Save button in modal
   1.9. Add event listener for Cancel button in modal
   1.10. Add validation for required fields before saving

2. Create Main Lookup Script
   2.1. Create `wwwroot/js/mcommunity-lookup.js`
   2.2. Add initialization function that runs on DOM ready
   2.3. Add event listener for form submit (prevent default)
   2.4. Add event listener for search button click
   2.5. Add event listener for Enter key in search input
   2.6. Check for credentials on page load, show warning if missing

3. Implement Input Validation Function
   3.1. Add function `validateSearchInput(searchTerm)`
   3.2. Check for empty/whitespace input
   3.3. Validate uniqname pattern: `/^[a-zA-Z0-9]{3,8}$/`
   3.4. Validate group pattern: `/^[a-zA-Z0-9_-]{9,62}$/`
   3.5. Return validation result with error message if invalid
   3.6. Add function `showValidationError(message)` to display validation errors
   3.7. Add function `clearValidationError()` to hide validation messages

4. Implement Credential Check Function
   4.1. Add function `checkCredentialsConfigured()`
   4.2. Call `getCredentials()` from settings module
   4.3. If credentials missing, show error message with link to settings
   4.4. Return boolean indicating if credentials are available
   4.5. Disable search if credentials not configured

5. Implement Main Lookup Function
   5.1. Add async function `performLookup(searchTerm)`
   5.2. Validate input using `validateSearchInput()`
   5.3. Check credentials using `checkCredentialsConfigured()`
   5.4. Show loading indicator
   5.5. Hide previous results and errors
   5.6. Get credentials from localStorage
   5.7. Build request object: `{ searchTerm, applicationId, password }`
   5.8. Make POST request to `/api/lookup` with fetch API
   5.9. Set headers: `Content-Type: application/json`
   5.10. Handle response (await json parsing)
   5.11. Hide loading indicator
   5.12. Call appropriate display function based on response

6. Implement Person Results Display Function
   6.1. Add function `displayPersonResults(personData)`
   6.2. Hide group results section
   6.3. Show person results section
   6.4. Populate display name (handle null)
   6.5. Populate uniqname
   6.6. Populate email addresses - iterate over array, handle multiple/null
   6.7. Populate phone numbers - iterate over array, handle multiple/null
   6.8. Populate titles - iterate over array, handle multiple/null
   6.9. Populate departments/organizational units - iterate over array, handle null
   6.10. Populate affiliations as badges - iterate over array, handle null
   6.11. Populate distinguished name
   6.12. Handle missing/null properties gracefully (show "Not available")
   6.13. Scroll to results section

7. Implement Group Results Display Function
   7.1. Add function `displayGroupResults(groupData)`
   7.2. Hide person results section
   7.3. Show group results section
   7.4. Populate group name (first cn value)
   7.5. Populate group email (append @umich.edu)
   7.6. Populate description (handle null)
   7.7. Populate owners count and create expandable list
   7.8. Populate members count and create expandable list (limit initial display to 10)
   7.9. Add "Show all" button for large member lists (>10)
   7.10. Populate timestamps (format dates nicely)
   7.11. Populate distinguished name
   7.12. Handle missing/null properties gracefully
   7.13. Scroll to results section

8. Implement Error Display Function
   8.1. Add function `displayError(errorMessage, errorCode)`
   8.2. Hide results sections
   8.3. Show error container
   8.4. Set error message text
   8.5. Add appropriate styling based on error type
   8.6. Handle specific error codes: NOT_FOUND, UNAUTHORIZED, FORBIDDEN, NETWORK_ERROR
   8.7. Add close button handler to dismiss error
   8.8. For UNAUTHORIZED, add link to open settings modal

9. Implement Loading Indicator Functions
   9.1. Add function `showLoading()` to display loading spinner
   9.2. Add function `hideLoading()` to hide loading spinner
   9.3. Add function to disable search input and button during loading
   9.4. Add function to re-enable search input and button after loading

10. Implement Helper Functions
    10.1. Add function `clearResults()` to hide all result sections
    10.2. Add function `scrollToResults()` to smooth scroll to results area
    10.3. Add function `formatDate(dateString)` to format ISO dates nicely
    10.4. Add function `createListItem(value)` to create list HTML elements
    10.5. Add function `createBadge(value)` to create Bootstrap badge elements
    10.6. Add function `escapeHtml(text)` to prevent XSS in displayed text

11. Add Error Handling for Fetch Calls
    11.1. Add try-catch around fetch call
    11.2. Handle network errors (fetch rejection)
    11.3. Handle timeout errors
    11.4. Handle non-OK HTTP responses
    11.5. Handle JSON parse errors
    11.6. Display appropriate user-friendly error messages
    11.7. Log errors to console for debugging

12. Test JavaScript Functionality
    12.1. Run application with `dotnet run`
    12.2. Test opening settings modal
    12.3. Test saving credentials to localStorage (check browser dev tools)
    12.4. Test retrieving credentials after page reload
    12.5. Test input validation with various inputs
    12.6. Test search without credentials (should show error)
    12.7. Test search with invalid format (should show validation error)
    12.8. Verify console shows no JavaScript errors
    12.9. Stop application

13. Add Script References to Layout
    13.1. Open `Views/Shared/_Layout.cshtml`
    13.2. Add script tag for `settings-modal.js` at bottom (before closing body)
    13.3. Add script tag for `mcommunity-lookup.js` after settings-modal.js
    13.4. Ensure jQuery loads before custom scripts
    13.5. Verify script order is correct

## Completion Notes:

