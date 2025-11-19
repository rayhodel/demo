# Task 3 - Create Game Controller and Views

Implement the main game controller and Razor views for the game interface.

## Status: Pending

## Dependencies: Task 1, Task 2

## Steps to Complete:

1. Create GameController
   1.1. Create `Controllers/GameController.cs`
   1.2. Inject SpaceInvadersDbContext via constructor
   1.3. Implement Index() action (returns main game view)
   1.4. Implement StartGame() action (initializes game session)
   1.5. Implement SaveScore(int score, string playerName) action
   1.6. Implement GetHighScores(int count = 10) action (returns JSON)
   1.7. Add proper error handling and logging

2. Create Game View
   2.1. Create `Views/Game/` folder
   2.2. Create `Views/Game/Index.cshtml`
   2.3. Add canvas element with id="gameCanvas"
   2.4. Create HUD section (score, lives, level displays)
   2.5. Add game over overlay (hidden by default)
   2.6. Add start/restart button
   2.7. Reference JavaScript and CSS files

3. Create Game Layout Partial
   3.1. Update `Views/Shared/_Layout.cshtml` for game styling
   3.2. Add navigation link to game page
   3.3. Ensure responsive viewport settings

4. Configure Routing
   4.1. Add route in Program.cs for /Game/Index as default game route
   4.2. Test routing to game controller actions

## Expected Outcomes:
- GameController with all CRUD actions for scores
- Game view with canvas and UI elements
- Layout configured for game
- All routes working correctly

## Files Created/Modified:
- Controllers/GameController.cs
- Views/Game/Index.cshtml
- Views/Shared/_Layout.cshtml
- Program.cs (routing)

## Completion Notes:
<!-- Update when task is completed -->
