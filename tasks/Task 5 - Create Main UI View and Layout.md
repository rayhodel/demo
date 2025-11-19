# Task 5 - Create Main UI View and Layout

Create the single-page user interface with search input, results display area, settings button, and modal dialog for API credentials.

## Status: Completed

## Dependencies: Task 1 - Initialize Project Structure

## Steps to Complete:

[x] 1. Update Shared Layout
   [x] 1.Open `Views/Shared/_Layout.cshtml`
   [x] 1.Update page title to "MCommunity Lookup"
   [x] 1.Add Bootstrap 5 CSS link (if not already present)
   [x] 1.Add custom `site.css` link in head section
   [x] 1.Remove unnecessary navigation menu items
   [x] 1.Add settings icon/button in header area (gear icon)
   [x] 1.Ensure jQuery and Bootstrap JS are loaded at bottom
   [x] 1.Add reference to custom JavaScript files (to be created)

[x] 2. Create Main Index View
   [x] 2.Open or create `Views/Home/Index.cshtml`
   [x] 2.Set ViewData["Title"] to "MCommunity Lookup"
   [x] 2.Add heading: "MCommunity Lookup"
   [x] 2.Add subtitle or description text

[x] 3. Create Search Input Section
   [x] 3.Add form element with id="lookupForm"
   [x] 3.Add input group with search icon
   [x] 3.Add text input with:
       - id="searchInput"
       - placeholder="Enter uniqname or group name..."
       - class="form-control"
       - autocomplete="off"
   [x] 3.Add search button with icon (magnifying glass) and text "Search"
   [x] 3.Add Enter key submit capability (via form submit)
   [x] 3.Add input validation styling (Bootstrap is-invalid class)

[x] 4. Create Validation Message Area
   [x] 4.Add div below input for validation messages
   [x] 4.Add id="validationMessage"
   [x] 4.Add Bootstrap alert classes (alert alert-danger)
   [x] 4.Initially hide with style="display: none;"
   [x] 4.Add close button (×) for dismissing messages

[x] 5. Create Loading Indicator
   [x] 5.Add spinner element (Bootstrap spinner or custom)
   [x] 5.Add id="loadingIndicator"
   [x] 5.Position below search input
   [x] 5.Initially hide with style="display: none;"
   [x] 5.Add loading text: "Searching..."

[x] 6. Create Results Display Container
   [x] 6.Add main results div with id="resultsContainer"
   [x] 6.Add horizontal rule or visual separator
   [x] 6.Initially hide or show "No results yet" message
   [x] 6.Add placeholder content explaining usage

[x] 7. Create Person Results Template Structure
   [x] 7.Add div for person results with id="personResults" (initially hidden)
   [x] 7.Add heading: "Person Information"
   [x] 7.Add card structure with Bootstrap classes
   [x] 7.Add sections for:
       - Display name (large, bold)
       - Uniqname
       - Email addresses (list, can be multiple)
       - Phone numbers (list, can be multiple)
       - Titles (list, can be multiple)
       - Departments/Organizational units (list)
       - Affiliations/Institutional roles (badges)
       - Distinguished name (small, muted)
   [x] 7.Use icons for each section (email, phone, briefcase, building, etc.)

[x] 8. Create Group Results Template Structure
   [x] 8.Add div for group results with id="groupResults" (initially hidden)
   [x] 8.Add heading: "Group Information"
   [x] 8.Add card structure with Bootstrap classes
   [x] 8.Add sections for:
       - Group name (large, bold)
       - Group email address
       - Description
       - Owners count and expandable list
       - Members count and expandable list
       - Created/modified timestamps
       - Distinguished name (small, muted)
   [x] 8.Use icons for each section (users, envelope, info, etc.)

[x] 9. Create Settings Modal Dialog
   [x] 9.Add Bootstrap modal structure with id="settingsModal"
   [x] 9.Add modal header with title "MCommunity API Settings" and close button
   [x] 9.Add modal body with form fields:
       - Label and input for Application ID (id="applicationIdInput")
       - Label and input for Password (id="passwordInput", type="password")
   [x] 9.Add warning message about credential storage in browser localStorage
   [x] 9.Add modal footer with "Cancel" and "Save" buttons
   [x] 9.Add appropriate ARIA labels for accessibility

[x] 10. Add Settings Button in Header
    10.1. In _Layout.cshtml header, add settings button
    10.2. Add gear icon (⚙️ or Font Awesome icon)
    10.3. Add id="settingsButton"
    10.4. Add click handler reference (handled in JS)
    10.5. Position in top-right corner of page

[x] 11. Add Custom CSS Styling
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

[x] 12. Add Error Display Section
    12.1. Add div for error messages with id="errorContainer"
    12.2. Add Bootstrap alert-danger classes
    12.3. Initially hide with style="display: none;"
    12.4. Add icon for error state (exclamation triangle)
    12.5. Add close button

[x] 13. Test View Rendering
    13.1. Run `dotnet run` and navigate to home page
    13.2. Verify page loads without errors
    13.3. Verify all sections are visible (except hidden results/errors)
    13.4. Verify settings button is visible and positioned correctly
    13.5. Verify settings modal can be opened (even without JS yet)
    13.6. Test responsive layout on different screen sizes
    13.7. Stop application

## Completion Notes:

Task 5 completed on November 19, 2025. Main UI View and Layout fully created:
- _Layout.cshtml updated with "MCommunity Lookup" branding, Bootstrap 5, custom site.css, settings button in header
- Index.cshtml created with ViewData["Title"] = "MCommunity Lookup", heading and subtitle
- Search input section with form id="lookupForm", text input id="searchInput", search button with magnifying glass icon
- Validation message area with id="validationMessage", Bootstrap alert-danger class, initially hidden, close button
- Loading indicator with spinner, id="loadingIndicator", initially hidden
- Results display container with id="resultsContainer", initial placeholder message
- Person results template with id="personResults", card structure, sections for display name, uniqname, emails, phones, titles, departments, affiliations (badges), DN
- Group results template with id="groupResults", card structure, sections for group name, email, description, owners (count and expandable list), members (count and expandable list), timestamps, DN
- Settings modal dialog with id="settingsModal", Bootstrap modal structure, form inputs for Application ID and Password, warning about localStorage, Cancel and Save buttons
- Settings button in header with gear icon, id="settingsButton", positioned top-right
- Error display section with id="errorContainer", alert-danger, initially hidden, close button
- Debug container with id="debugContainer" for troubleshooting
- Custom CSS styling in site.css for search container, cards, icons, badges, loading, settings button, responsive breakpoints
- ARIA labels added for accessibility
- Icons used: 🔍 search, 👤 person, 📧 email, 📞 phone, 💼 title, 🏢 department, 🎓 affiliations, 👥 group, ⚙️ settings, ⚠️ error
- Page loads and renders correctly

