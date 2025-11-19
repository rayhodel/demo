# Task 6 - Implement Client-Side JavaScript

Create all client-side JavaScript functionality for handling search, API calls, credential management, and dynamic results display.

## Status: Completed

## Dependencies: Task 4 - Create API Controller and Backend Logic, Task 5 - Create Main UI View and Layout

## Steps to Complete:

[x] 1. Create Settings Management Script
   [x] 1.Create `wwwroot/js/settings-modal.js`
   [x] 1.Add function `openSettingsModal()` to show modal and load current credentials
   [x] 1.Add function `closeSettingsModal()` to hide modal
   [x] 1.Add function `saveCredentials()` to save Application ID and Password to localStorage
   [x] 1.Add function `getCredentials()` to retrieve credentials from localStorage
   [x] 1.Add function `hasCredentials()` to check if credentials exist
   [x] 1.Add event listener for settings button click
   [x] 1.Add event listener for Save button in modal
   [x] 1.Add event listener for Cancel button in modal
   [x] 1.Add validation for required fields before saving

[x] 2. Create Main Lookup Script
   [x] 2.Create `wwwroot/js/mcommunity-lookup.js`
   [x] 2.Add initialization function that runs on DOM ready
   [x] 2.Add event listener for form submit (prevent default)
   [x] 2.Add event listener for search button click
   [x] 2.Add event listener for Enter key in search input
   [x] 2.Check for credentials on page load, show warning if missing

[x] 3. Implement Input Validation Function
   [x] 3.Add function `validateSearchInput(searchTerm)`
   [x] 3.Check for empty/whitespace input
   [x] 3.Validate uniqname pattern: `/^[a-zA-Z0-9]{3,8}$/`
   [x] 3.Validate group pattern: `/^[a-zA-Z0-9_-]{9,62}$/`
   [x] 3.Return validation result with error message if invalid
   [x] 3.Add function `showValidationError(message)` to display validation errors
   [x] 3.Add function `clearValidationError()` to hide validation messages

[x] 4. Implement Credential Check Function
   [x] 4.Add function `checkCredentialsConfigured()`
   [x] 4.Call `getCredentials()` from settings module
   [x] 4.If credentials missing, show error message with link to settings
   [x] 4.Return boolean indicating if credentials are available
   [x] 4.Disable search if credentials not configured

[x] 5. Implement Main Lookup Function
   [x] 5.Add async function `performLookup(searchTerm)`
   [x] 5.Validate input using `validateSearchInput()`
   [x] 5.Check credentials using `checkCredentialsConfigured()`
   [x] 5.Show loading indicator
   [x] 5.Hide previous results and errors
   [x] 5.Get credentials from localStorage
   [x] 5.Build request object: `{ searchTerm, applicationId, password }`
   [x] 5.Make POST request to `/api/lookup` with fetch API
   [x] 5.Set headers: `Content-Type: application/json`
   [x] 5.Handle response (await json parsing)
   [x] 5.Hide loading indicator
   [x] 5.Call appropriate display function based on response

[x] 6. Implement Person Results Display Function
   [x] 6.Add function `displayPersonResults(personData)`
   [x] 6.Hide group results section
   [x] 6.Show person results section
   [x] 6.Populate display name (handle null)
   [x] 6.Populate uniqname
   [x] 6.Populate email addresses - iterate over array, handle multiple/null
   [x] 6.Populate phone numbers - iterate over array, handle multiple/null
   [x] 6.Populate titles - iterate over array, handle multiple/null
   [x] 6.Populate departments/organizational units - iterate over array, handle null
   [x] 6.Populate affiliations as badges - iterate over array, handle null
   [x] 6.Populate distinguished name
   [x] 6.Handle missing/null properties gracefully (show "Not available")
   [x] 6.Scroll to results section

[x] 7. Implement Group Results Display Function
   [x] 7.Add function `displayGroupResults(groupData)`
   [x] 7.Hide person results section
   [x] 7.Show group results section
   [x] 7.Populate group name (first cn value)
   [x] 7.Populate group email (append @umich.edu)
   [x] 7.Populate description (handle null)
   [x] 7.Populate owners count and create expandable list
   [x] 7.Populate members count and create expandable list (limit initial display to 10)
   [x] 7.Add "Show all" button for large member lists (>10)
   [x] 7.Populate timestamps (format dates nicely)
   [x] 7.Populate distinguished name
   [x] 7.Handle missing/null properties gracefully
   [x] 7.Scroll to results section

[x] 8. Implement Error Display Function
   [x] 8.Add function `displayError(errorMessage, errorCode)`
   [x] 8.Hide results sections
   [x] 8.Show error container
   [x] 8.Set error message text
   [x] 8.Add appropriate styling based on error type
   [x] 8.Handle specific error codes: NOT_FOUND, UNAUTHORIZED, FORBIDDEN, NETWORK_ERROR
   [x] 8.Add close button handler to dismiss error
   [x] 8.For UNAUTHORIZED, add link to open settings modal

[x] 9. Implement Loading Indicator Functions
   [x] 9.Add function `showLoading()` to display loading spinner
   [x] 9.Add function `hideLoading()` to hide loading spinner
   [x] 9.Add function to disable search input and button during loading
   [x] 9.Add function to re-enable search input and button after loading

[x] 10. Implement Helper Functions
    10.1. Add function `clearResults()` to hide all result sections
    10.2. Add function `scrollToResults()` to smooth scroll to results area
    10.3. Add function `formatDate(dateString)` to format ISO dates nicely
    10.4. Add function `createListItem(value)` to create list HTML elements
    10.5. Add function `createBadge(value)` to create Bootstrap badge elements
    10.6. Add function `escapeHtml(text)` to prevent XSS in displayed text

[x] 11. Add Error Handling for Fetch Calls
    11.1. Add try-catch around fetch call
    11.2. Handle network errors (fetch rejection)
    11.3. Handle timeout errors
    11.4. Handle non-OK HTTP responses
    11.5. Handle JSON parse errors
    11.6. Display appropriate user-friendly error messages
    11.7. Log errors to console for debugging

[x] 12. Test JavaScript Functionality
    12.1. Run application with `dotnet run`
    12.2. Test opening settings modal
    12.3. Test saving credentials to localStorage (check browser dev tools)
    12.4. Test retrieving credentials after page reload
    12.5. Test input validation with various inputs
    12.6. Test search without credentials (should show error)
    12.7. Test search with invalid format (should show validation error)
    12.8. Verify console shows no JavaScript errors
    12.9. Stop application

[x] 13. Add Script References to Layout
    13.1. Open `Views/Shared/_Layout.cshtml`
    13.2. Add script tag for `settings-modal.js` at bottom (before closing body)
    13.3. Add script tag for `mcommunity-lookup.js` after settings-modal.js
    13.4. Ensure jQuery loads before custom scripts
    13.5. Verify script order is correct

## Completion Notes:

Task 6 completed on November 19, 2025. Client-side JavaScript fully implemented:
- settings-modal.js created with openSettingsModal, closeSettingsModal, saveCredentials, getCredentials, hasCredentials, clearCredentials functions
- Credentials saved/retrieved from localStorage with key 'mcommunity_api_credentials'
- Event listeners for settings button, save button, cancel button, form submit
- Validation for required fields before saving credentials
- Success message shown after saving settings
- MCommunitySettings exported as global object for use by other scripts
- mcommunity-lookup.js created with initialization function on DOM ready
- Event listeners for form submit, search button click, Enter key, alert close buttons
- validateSearchInput function with regex patterns: /^[a-zA-Z0-9]{3,8}$/ for uniqname, /^[a-zA-Z0-9_-]{9,62}$/ for group
- checkCredentialsConfigured function shows error if credentials missing
- performLookup async function makes POST to /api/lookup with fetch API, handles response/errors
- displayPersonResults populates all person fields: displayName, uid, emails (array), phones (array), titles (array), departments (array), affiliations (badges), DN
- displayGroupResults populates all group fields: name, email, description, owners (expandable list), members (expandable with "Show all" for >10), timestamps, DN
- displayError function shows error container with message and error code, adds link to settings for UNAUTHORIZED/MISSING_CREDENTIALS
- showLoading/hideLoading functions control spinner and disable inputs during API calls
- Helper functions: clearResults, scrollToResults, formatDate, createListItem, createBadge, escapeHtml (prevents XSS)
- extractUniqnameFromDn function extracts uid from DN strings
- Error handling for fetch network errors, timeouts, JSON parse errors with user-friendly messages
- showDebug function for troubleshooting JSON parse errors
- Script references added to _Layout.cshtml: settings-modal.js and mcommunity-lookup.js after jQuery/Bootstrap
- No JavaScript console errors on page load

