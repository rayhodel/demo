# Task 4 - Set Up Static Assets Structure

Create the folder structure and placeholder files for game assets (JavaScript, CSS, images, sounds).

## Status: Pending

## Dependencies: Task 1

## Steps to Complete:

1. Create wwwroot Folder Structure
   1.1. Verify `wwwroot/` exists (should be created by MVC template)
   1.2. Create `wwwroot/css/` folder
   1.3. Create `wwwroot/js/` folder
   1.4. Create `wwwroot/images/` folder with subfolders:
        - `wwwroot/images/sprites/`
        - `wwwroot/images/ui/`
   1.5. Create `wwwroot/sounds/` folder

2. Create CSS Files
   2.1. Create `wwwroot/css/game.css` with base game styles:
        - Canvas container styling
        - HUD layout
        - Game over overlay
        - Button styles
   2.2. Create `wwwroot/css/leaderboard.css` for future leaderboard page

3. Create JavaScript Module Files
   3.1. Create `wwwroot/js/game.js` (main game orchestrator)
   3.2. Create `wwwroot/js/gameEngine.js` (game loop and logic)
   3.3. Create `wwwroot/js/renderer.js` (canvas rendering)
   3.4. Create `wwwroot/js/inputHandler.js` (keyboard input)
   3.5. Create `wwwroot/js/entityManager.js` (entity lifecycle)
   3.6. Create `wwwroot/js/audioManager.js` (sound management)
   3.7. Create `wwwroot/js/api.js` (server communication)
   3.8. Add basic module structure with comments in each file

4. Create Placeholder Assets
   4.1. Create README.md files in image and sound folders explaining asset requirements
   4.2. Document sprite dimensions and formats needed
   4.3. Document audio file formats and specifications

5. Configure Static File Serving
   5.1. Verify Program.cs has app.UseStaticFiles() middleware
   5.2. Test that static files are served correctly
   5.3. Configure MIME types if needed for audio files

## Expected Outcomes:
- Complete wwwroot folder structure
- All JavaScript modules created with skeleton code
- CSS files with base styling
- Static file serving configured
- Asset requirement documentation

## Files Created/Modified:
- wwwroot/css/game.css
- wwwroot/css/leaderboard.css
- wwwroot/js/game.js
- wwwroot/js/gameEngine.js
- wwwroot/js/renderer.js
- wwwroot/js/inputHandler.js
- wwwroot/js/entityManager.js
- wwwroot/js/audioManager.js
- wwwroot/js/api.js
- wwwroot/images/README.md
- wwwroot/sounds/README.md
- Program.cs (verify static files middleware)

## Completion Notes:
<!-- Update when task is completed -->
