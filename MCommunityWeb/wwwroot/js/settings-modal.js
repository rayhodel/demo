/**
 * Settings Modal Management
 * Handles API credential storage and retrieval using browser localStorage
 */

(function () {
    'use strict';

    const STORAGE_KEY = 'mcommunity_api_credentials';

    /**
     * Opens the settings modal and loads current credentials
     */
    function openSettingsModal() {
        const credentials = getCredentials();
        
        if (credentials) {
            document.getElementById('applicationIdInput').value = credentials.applicationId || '';
            document.getElementById('passwordInput').value = credentials.password || '';
        }

        const settingsModal = new bootstrap.Modal(document.getElementById('settingsModal'));
        settingsModal.show();
    }

    /**
     * Saves credentials to localStorage
     */
    function saveCredentials() {
        const applicationId = document.getElementById('applicationIdInput').value.trim();
        const password = document.getElementById('passwordInput').value.trim();

        // Validate required fields
        if (!applicationId || !password) {
            alert('Both Application ID and Password are required.');
            return;
        }

        // Store credentials
        const credentials = {
            applicationId: applicationId,
            password: password
        };

        try {
            localStorage.setItem(STORAGE_KEY, JSON.stringify(credentials));
            
            // Close modal
            const settingsModal = bootstrap.Modal.getInstance(document.getElementById('settingsModal'));
            settingsModal.hide();

            // Show success message
            showSuccessMessage('Settings saved successfully!');
        } catch (error) {
            console.error('Error saving credentials:', error);
            alert('Failed to save credentials. Please try again.');
        }
    }

    /**
     * Retrieves credentials from localStorage
     * @returns {object|null} Credentials object or null if not found
     */
    function getCredentials() {
        try {
            const stored = localStorage.getItem(STORAGE_KEY);
            if (stored) {
                return JSON.parse(stored);
            }
        } catch (error) {
            console.error('Error retrieving credentials:', error);
        }
        return null;
    }

    /**
     * Checks if credentials are configured
     * @returns {boolean} True if credentials exist
     */
    function hasCredentials() {
        const creds = getCredentials();
        return creds && creds.applicationId && creds.password;
    }

    /**
     * Clears stored credentials
     */
    function clearCredentials() {
        try {
            localStorage.removeItem(STORAGE_KEY);
        } catch (error) {
            console.error('Error clearing credentials:', error);
        }
    }

    /**
     * Shows a temporary success message
     */
    function showSuccessMessage(message) {
        // Create a temporary alert
        const alert = document.createElement('div');
        alert.className = 'alert alert-success alert-dismissible fade show position-fixed top-0 start-50 translate-middle-x mt-3';
        alert.style.zIndex = '9999';
        alert.innerHTML = `
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        `;
        
        document.body.appendChild(alert);

        // Auto-dismiss after 3 seconds
        setTimeout(() => {
            alert.remove();
        }, 3000);
    }

    // Event Listeners
    document.addEventListener('DOMContentLoaded', function () {
        // Settings button click
        const settingsButton = document.getElementById('settingsButton');
        if (settingsButton) {
            settingsButton.addEventListener('click', openSettingsModal);
        }

        // Save settings button click
        const saveButton = document.getElementById('saveSettingsButton');
        if (saveButton) {
            saveButton.addEventListener('click', saveCredentials);
        }

        // Enter key in settings form
        const settingsForm = document.getElementById('settingsForm');
        if (settingsForm) {
            settingsForm.addEventListener('submit', function (e) {
                e.preventDefault();
                saveCredentials();
            });
        }

        // Check if credentials are configured on load
        if (!hasCredentials()) {
            console.info('API credentials not configured. Click Settings to configure.');
        }
    });

    // Export functions for use by other scripts
    window.MCommunitySettings = {
        getCredentials: getCredentials,
        hasCredentials: hasCredentials,
        openSettingsModal: openSettingsModal,
        clearCredentials: clearCredentials
    };
})();
