/**
 * MCommunity Lookup
 * Handles search, API calls, and results display
 */

(function () {
    'use strict';

    // Regex patterns for validation
    const UNIQNAME_PATTERN = /^[a-zA-Z0-9]{3,8}$/;
    const GROUP_PATTERN = /^[a-zA-Z0-9_-]{9,62}$/;

    /**
     * Initialize the lookup functionality
     */
    function init() {
        // Form submit handler
        const lookupForm = document.getElementById('lookupForm');
        if (lookupForm) {
            lookupForm.addEventListener('submit', function (e) {
                e.preventDefault();
                const searchTerm = document.getElementById('searchInput').value.trim();
                if (searchTerm) {
                    performLookup(searchTerm);
                }
            });
        }

        // Search button click
        const searchButton = document.getElementById('searchButton');
        if (searchButton) {
            searchButton.addEventListener('click', function (e) {
                e.preventDefault();
                const searchTerm = document.getElementById('searchInput').value.trim();
                if (searchTerm) {
                    performLookup(searchTerm);
                }
            });
        }

        // Close buttons for alerts
        document.addEventListener('click', function (e) {
            if (e.target.classList.contains('btn-close')) {
                const alert = e.target.closest('.alert');
                if (alert) {
                    alert.style.display = 'none';
                }
            }
        });

        // Check credentials on load
        checkCredentialsOnLoad();
    }

    /**
     * Checks if credentials are configured and shows warning if not
     */
    function checkCredentialsOnLoad() {
        if (!window.MCommunitySettings.hasCredentials()) {
            showValidationError('⚙️ Please configure your API credentials in Settings before searching.');
        }
    }

    /**
     * Validates search input
     */
    function validateSearchInput(searchTerm) {
        if (!searchTerm || searchTerm.trim() === '') {
            return { valid: false, message: 'Search term is required.' };
        }

        const trimmed = searchTerm.trim();

        if (UNIQNAME_PATTERN.test(trimmed) || GROUP_PATTERN.test(trimmed)) {
            return { valid: true };
        }

        return {
            valid: false,
            message: 'Invalid format. Uniqname: 3-8 alphanumeric characters. Group: 9-62 characters (alphanumeric, dash, underscore).'
        };
    }

    /**
     * Main lookup function
     */
    async function performLookup(searchTerm) {
        // Clear previous messages
        clearValidationError();
        clearError();
        clearDebug();

        // Validate input
        const validation = validateSearchInput(searchTerm);
        if (!validation.valid) {
            showValidationError(validation.message);
            return;
        }

        // Check credentials
        if (!window.MCommunitySettings.hasCredentials()) {
            showError('Please configure your API credentials in Settings.', 'MISSING_CREDENTIALS');
            return;
        }

        // Get credentials
        const credentials = window.MCommunitySettings.getCredentials();

        // Show loading
        showLoading();
        clearResults();

        try {
            // Make API call
            const response = await fetch('/api/lookup', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    searchTerm: searchTerm,
                    applicationId: credentials.applicationId,
                    password: credentials.password
                })
            });

            const responseText = await response.text();
            let result;
            
            try {
                result = JSON.parse(responseText);
            } catch (parseError) {
                // Show debug info if JSON parse fails
                showDebug('Response Parse Error', {
                    status: response.status,
                    statusText: response.statusText,
                    responseBody: responseText.substring(0, 1000)
                });
                throw new Error('Invalid JSON response from server');
            }

            hideLoading();

            if (result.success) {
                // Display results based on type
                if (result.type === 'person') {
                    displayPersonResults(result.data);
                } else if (result.type === 'group') {
                    displayGroupResults(result.data);
                }
                scrollToResults();
            } else {
                // Display error
                showError(result.error || 'An error occurred', result.errorCode);
            }
        } catch (error) {
            hideLoading();
            console.error('Lookup error:', error);
            showError('Network error. Please check your connection and try again.', 'NETWORK_ERROR');
        }
    }

    /**
     * Displays person results
     */
    function displayPersonResults(person) {
        clearResults();

        // Show person results section
        const personResults = document.getElementById('personResults');
        personResults.style.display = 'block';

        // Display name
        document.getElementById('personDisplayName').textContent = person.displayName || 'N/A';

        // Uniqname
        document.getElementById('personUid').textContent = person.uid || 'N/A';

        // Emails
        displayList('personEmails', person.mail, 'personEmailSection');

        // Phones
        displayList('personPhones', person.telephoneNumber, 'personPhoneSection');

        // Titles
        displayList('personTitles', person.title, 'personTitleSection');

        // Departments
        displayList('personDepartments', person.ou, 'personDepartmentSection');

        // Affiliations (as badges)
        displayAffiliations(person.umichAffiliation);

        // DN
        document.getElementById('personDn').textContent = person.dn || 'N/A';
    }

    /**
     * Displays group results
     */
    function displayGroupResults(group) {
        clearResults();

        // Show group results section
        const groupResults = document.getElementById('groupResults');
        groupResults.style.display = 'block';

        // Group name
        const groupName = (group.cn && group.cn.length > 0) ? group.cn[0] : 'N/A';
        document.getElementById('groupName').textContent = groupName;

        // Email
        const groupEmail = group.umichGroupEmail ? `${group.umichGroupEmail}@umich.edu` : 'N/A';
        document.getElementById('groupEmail').textContent = groupEmail;

        // Description
        if (group.umichDescription) {
            document.getElementById('groupDescription').textContent = group.umichDescription;
            document.getElementById('groupDescriptionSection').style.display = 'block';
        } else {
            document.getElementById('groupDescriptionSection').style.display = 'none';
        }

        // Owners
        displayMembers('groupOwners', group.owner, 'ownerCount');

        // Members
        displayMembers('groupMembers', group.member, 'memberCount');

        // Timestamps
        document.getElementById('groupCreated').textContent = formatDate(group.createTimestamp);
        document.getElementById('groupModified').textContent = formatDate(group.modifyTimestamp);

        // DN
        document.getElementById('groupDn').textContent = group.dn || 'N/A';
    }

    /**
     * Displays a list of items
     */
    function displayList(elementId, items, sectionId) {
        const element = document.getElementById(elementId);
        const section = document.getElementById(sectionId);

        if (items && items.length > 0) {
            element.innerHTML = items.map(item => `<li>${escapeHtml(item)}</li>`).join('');
            section.style.display = 'block';
        } else {
            section.style.display = 'none';
        }
    }

    /**
     * Displays affiliations as badges
     */
    function displayAffiliations(affiliations) {
        const element = document.getElementById('personAffiliations');
        const section = document.getElementById('personAffiliationSection');

        if (affiliations && affiliations.length > 0) {
            element.innerHTML = affiliations
                .map(aff => `<span class="badge bg-secondary">${escapeHtml(aff)}</span>`)
                .join(' ');
            section.style.display = 'block';
        } else {
            section.style.display = 'none';
        }
    }

    /**
     * Displays group members or owners
     */
    function displayMembers(elementId, members, countId) {
        const element = document.getElementById(elementId);
        const countElement = document.getElementById(countId);

        if (members && members.length > 0) {
            countElement.textContent = members.length;

            // Show first 10, with option to show more
            const displayCount = Math.min(members.length, 10);
            let html = '<ul class="list-unstyled mb-0">';

            for (let i = 0; i < displayCount; i++) {
                const uniqname = extractUniqnameFromDn(members[i]) || members[i];
                html += `<li class="small">${escapeHtml(uniqname)}</li>`;
            }

            html += '</ul>';

            if (members.length > 10) {
                html += `<button class="btn btn-sm btn-link show-more-btn" onclick="showAllMembers('${elementId}', ${JSON.stringify(members).replace(/"/g, '&quot;')})">Show all ${members.length} members</button>`;
            }

            element.innerHTML = html;
        } else {
            countElement.textContent = '0';
            element.innerHTML = '<span class="text-muted small">None</span>';
        }
    }

    /**
     * Shows all members (called from button)
     */
    window.showAllMembers = function (elementId, members) {
        const element = document.getElementById(elementId);
        let html = '<ul class="list-unstyled mb-0 scrollable-list">';

        members.forEach(member => {
            const uniqname = extractUniqnameFromDn(member) || member;
            html += `<li class="small">${escapeHtml(uniqname)}</li>`;
        });

        html += '</ul>';
        element.innerHTML = html;
    };

    /**
     * Extracts uniqname from DN
     */
    function extractUniqnameFromDn(dn) {
        if (!dn) return null;
        const match = dn.match(/uid=([^,]+)/i);
        return match ? match[1] : null;
    }

    /**
     * Formats a date string
     */
    function formatDate(dateString) {
        if (!dateString) return 'N/A';
        try {
            const date = new Date(dateString);
            return date.toLocaleDateString() + ' ' + date.toLocaleTimeString();
        } catch {
            return dateString;
        }
    }

    /**
     * Escapes HTML to prevent XSS
     */
    function escapeHtml(text) {
        const div = document.createElement('div');
        div.textContent = text;
        return div.innerHTML;
    }

    /**
     * Shows loading indicator
     */
    function showLoading() {
        document.getElementById('loadingIndicator').style.display = 'block';
        document.getElementById('searchButton').disabled = true;
        document.getElementById('searchInput').disabled = true;
    }

    /**
     * Hides loading indicator
     */
    function hideLoading() {
        document.getElementById('loadingIndicator').style.display = 'none';
        document.getElementById('searchButton').disabled = false;
        document.getElementById('searchInput').disabled = false;
    }

    /**
     * Shows validation error
     */
    function showValidationError(message) {
        const validationMessage = document.getElementById('validationMessage');
        const validationText = document.getElementById('validationText');
        validationText.textContent = message;
        validationMessage.style.display = 'block';
    }

    /**
     * Clears validation error
     */
    function clearValidationError() {
        document.getElementById('validationMessage').style.display = 'none';
    }

    /**
     * Shows error message
     */
    function showError(message, errorCode) {
        const errorContainer = document.getElementById('errorContainer');
        const errorMessage = document.getElementById('errorMessage');

        let displayMessage = message;

        // Add link to settings for credential errors
        if (errorCode === 'UNAUTHORIZED' || errorCode === 'MISSING_CREDENTIALS') {
            displayMessage += ' <a href="#" onclick="window.MCommunitySettings.openSettingsModal(); return false;">Open Settings</a>';
        }

        errorMessage.innerHTML = displayMessage;
        errorContainer.style.display = 'block';
        scrollToResults();
    }

    /**
     * Clears error message
     */
    function clearError() {
        document.getElementById('errorContainer').style.display = 'none';
    }

    /**
     * Shows debug information
     */
    function showDebug(title, data) {
        const debugContainer = document.getElementById('debugContainer');
        const debugContent = document.getElementById('debugContent');
        
        let debugText = `${title}\n\n`;
        debugText += JSON.stringify(data, null, 2);
        
        debugContent.textContent = debugText;
        debugContainer.style.display = 'block';
        scrollToResults();
    }

    /**
     * Clears debug information
     */
    function clearDebug() {
        document.getElementById('debugContainer').style.display = 'none';
    }

    /**
     * Clears all results
     */
    function clearResults() {
        document.getElementById('initialMessage').style.display = 'none';
        document.getElementById('personResults').style.display = 'none';
        document.getElementById('groupResults').style.display = 'none';
    }

    /**
     * Scrolls to results area
     */
    function scrollToResults() {
        const resultsContainer = document.getElementById('resultsContainer');
        if (resultsContainer) {
            resultsContainer.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
    }

    // Initialize on DOM ready
    document.addEventListener('DOMContentLoaded', init);
})();
