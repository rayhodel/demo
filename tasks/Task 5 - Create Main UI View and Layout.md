# Task 5 - Create Main UI View and Layout

Create the single-page user interface with search input, results display area, settings button, and modal dialog for API credentials.

## Status: Pending

## Dependencies: Task 1 - Initialize Project Structure

## Steps to Complete:

1. Update Shared Layout
   1.1. Open `Views/Shared/_Layout.cshtml`
   1.2. Update page title to "MCommunity Lookup"
   1.3. Add Bootstrap 5 CSS link (if not already present)
   1.4. Add custom `site.css` link in head section
   1.5. Remove unnecessary navigation menu items
   1.6. Add settings icon/button in header area (gear icon)
   1.7. Ensure jQuery and Bootstrap JS are loaded at bottom
   1.8. Add reference to custom JavaScript files (to be created)

2. Create Main Index View
   2.1. Open or create `Views/Home/Index.cshtml`
   2.2. Set ViewData["Title"] to "MCommunity Lookup"
   2.3. Add heading: "MCommunity Lookup"
   2.4. Add subtitle or description text

3. Create Search Input Section
   3.1. Add form element with id="lookupForm"
   3.2. Add input group with search icon
   3.3. Add text input with:
       - id="searchInput"
       - placeholder="Enter uniqname or group name..."
       - class="form-control"
       - autocomplete="off"
   3.4. Add search button with icon (magnifying glass) and text "Search"
   3.5. Add Enter key submit capability (via form submit)
   3.6. Add input validation styling (Bootstrap is-invalid class)

4. Create Validation Message Area
   4.1. Add div below input for validation messages
   4.2. Add id="validationMessage"
   4.3. Add Bootstrap alert classes (alert alert-danger)
   4.4. Initially hide with style="display: none;"
   4.5. Add close button (×) for dismissing messages

5. Create Loading Indicator
   5.1. Add spinner element (Bootstrap spinner or custom)
   5.2. Add id="loadingIndicator"
   5.3. Position below search input
   5.4. Initially hide with style="display: none;"
   5.5. Add loading text: "Searching..."

6. Create Results Display Container
   6.1. Add main results div with id="resultsContainer"
   6.2. Add horizontal rule or visual separator
   6.3. Initially hide or show "No results yet" message
   6.4. Add placeholder content explaining usage

7. Create Person Results Template Structure
   7.1. Add div for person results with id="personResults" (initially hidden)
   7.2. Add heading: "Person Information"
   7.3. Add card structure with Bootstrap classes
   7.4. Add sections for:
       - Display name (large, bold)
       - Uniqname
       - Email addresses (list, can be multiple)
       - Phone numbers (list, can be multiple)
       - Titles (list, can be multiple)
       - Departments/Organizational units (list)
       - Affiliations/Institutional roles (badges)
       - Distinguished name (small, muted)
   7.5. Use icons for each section (email, phone, briefcase, building, etc.)

8. Create Group Results Template Structure
   8.1. Add div for group results with id="groupResults" (initially hidden)
   8.2. Add heading: "Group Information"
   8.3. Add card structure with Bootstrap classes
   8.4. Add sections for:
       - Group name (large, bold)
       - Group email address
       - Description
       - Owners count and expandable list
       - Members count and expandable list
       - Created/modified timestamps
       - Distinguished name (small, muted)
   8.5. Use icons for each section (users, envelope, info, etc.)

9. Create Settings Modal Dialog
   9.1. Add Bootstrap modal structure with id="settingsModal"
   9.2. Add modal header with title "MCommunity API Settings" and close button
   9.3. Add modal body with form fields:
       - Label and input for Application ID (id="applicationIdInput")
       - Label and input for Password (id="passwordInput", type="password")
   9.4. Add warning message about credential storage in browser localStorage
   9.5. Add modal footer with "Cancel" and "Save" buttons
   9.6. Add appropriate ARIA labels for accessibility

10. Add Settings Button in Header
    10.1. In _Layout.cshtml header, add settings button
    10.2. Add gear icon (⚙️ or Font Awesome icon)
    10.3. Add id="settingsButton"
    10.4. Add click handler reference (handled in JS)
    10.5. Position in top-right corner of page

11. Add Custom CSS Styling
    11.1. Open `wwwroot/css/site.css`
    11.2. Add styles for search input container
    11.3. Add styles for results cards (padding, margins, borders)
    11.4. Add styles for person/group sections
    11.5. Add styles for icons and badges
    11.6. Add styles for loading indicator
    11.7. Add styles for settings button positioning
    11.8. Add responsive breakpoints for mobile devices
    11.9. Add hover states for interactive elements
    11.10. Add styles for collapsible member/owner lists

12. Add Error Display Section
    12.1. Add div for error messages with id="errorContainer"
    12.2. Add Bootstrap alert-danger classes
    12.3. Initially hide with style="display: none;"
    12.4. Add icon for error state (exclamation triangle)
    12.5. Add close button

13. Test View Rendering
    13.1. Run `dotnet run` and navigate to home page
    13.2. Verify page loads without errors
    13.3. Verify all sections are visible (except hidden results/errors)
    13.4. Verify settings button is visible and positioned correctly
    13.5. Verify settings modal can be opened (even without JS yet)
    13.6. Test responsive layout on different screen sizes
    13.7. Stop application

## Completion Notes:

