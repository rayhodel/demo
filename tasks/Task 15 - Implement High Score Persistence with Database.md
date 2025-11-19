# Task 15 - Implement High Score Persistence with Database

Connect the game to the backend API to save and retrieve high scores from the database.

## Status: Pending

## Dependencies: Task 2, Task 3, Task 12

## Steps to Complete:

1. Implement API Communication (api.js)
   1.1. Create ApiService class
   1.2. Implement saveScore(playerName, score, level) method
   1.3. Implement getHighScores(limit) method
   1.4. Use fetch API for HTTP requests
   1.5. Add error handling and retry logic
   1.6. Add loading indicators

2. Update Game Controller Actions
   2.1. Verify SaveScore action is working:
        - Accepts score, playerName, level
        - Creates GameSession record
        - Creates/updates HighScore record
        - Returns success/error response
   2.2. Verify GetHighScores action:
        - Returns top N high scores
        - Ordered by score descending
        - Returns JSON format

3. Add Name Entry Dialog
   3.1. Create modal/overlay for name entry
   3.2. Show after game over if high score
   3.3. Add text input for player name
   3.4. Validate name (3-20 characters, alphanumeric)
   3.5. Add submit and cancel buttons
   3.6. Handle form submission

4. Integrate Score Saving into Game
   4.1. Check if score qualifies for high score list
   4.2. Prompt for name if high score
   4.3. Call API to save score
   4.4. Show success/error message
   4.5. Update local high score display
   4.6. Handle network errors gracefully

5. Create High Scores Display
   5.1. Add high scores section to game page
   5.2. Fetch and display top 10 scores
   5.3. Format score display nicely
   5.4. Highlight current player's score
   5.5. Refresh scores after game over
   5.6. Add loading state

6. Implement Local Storage Fallback
   6.1. Use localStorage if API unavailable
   6.2. Save scores locally
   6.3. Sync with server when available
   6.4. Show offline indicator

7. Add Player Stats Tracking
   7.1. Track games played
   7.2. Track total enemies destroyed
   7.3. Track highest level reached
   7.4. Display stats on game over
   7.5. Save stats to database

## Expected Outcomes:
- Scores saved to database after each game
- High scores retrieved and displayed
- Name entry prompt for high scores
- Graceful handling of network errors
- Local storage fallback works
- Player stats tracked
- API integration is reliable

## Files Created/Modified:
- wwwroot/js/api.js (complete implementation)
- Controllers/GameController.cs (verify/enhance)
- Views/Game/Index.cshtml (name entry modal, high scores display)
- wwwroot/css/game.css (modal styling)
- Models/GameSession.cs (verify)
- Models/HighScore.cs (verify)

## Testing Checklist:
- [ ] Score saves successfully to database
- [ ] High scores retrieved correctly
- [ ] Top 10 displayed on page
- [ ] Name entry modal appears for high score
- [ ] Name validation works
- [ ] Score submission successful
- [ ] Error handling works
- [ ] Local storage fallback works
- [ ] Offline mode functions
- [ ] Stats tracked correctly
- [ ] API calls don't block game
- [ ] Network errors don't crash game

## Completion Notes:
<!-- Update when task is completed -->
