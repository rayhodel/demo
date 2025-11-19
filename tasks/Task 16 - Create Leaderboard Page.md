# Task 16 - Create Leaderboard Page

Build a dedicated leaderboard page to display high scores with filtering and sorting.

## Status: Pending

## Dependencies: Task 2, Task 15

## Steps to Complete:

1. Create Leaderboard Controller
   1.1. Create `Controllers/LeaderboardController.cs`
   1.2. Inject SpaceInvadersDbContext
   1.3. Implement Index() action
   1.4. Implement GetScores() API action with parameters:
        - limit (default 50)
        - skip (for pagination)
        - filter by date range
   1.5. Add error handling

2. Create Leaderboard View
   2.1. Create `Views/Leaderboard/` folder
   2.2. Create `Views/Leaderboard/Index.cshtml`
   2.3. Add page title and description
   2.4. Create table structure for scores:
        - Rank column
        - Player name column
        - Score column
        - Level column
        - Date column
   2.5. Add "Back to Game" navigation

3. Style Leaderboard Page
   3.1. Enhance `wwwroot/css/leaderboard.css`
   3.2. Style table with alternating rows
   3.3. Highlight top 3 scores (gold, silver, bronze)
   3.4. Add hover effects
   3.5. Make responsive for mobile
   3.6. Add retro/arcade theme consistent with game

4. Add Filtering Options
   4.1. Add filter controls:
        - All time
        - This week
        - This month
        - Today
   4.2. Implement filter buttons
   4.3. Add AJAX call to reload scores with filter
   4.4. Update table without page refresh

5. Add Pagination
   5.1. Show 25 scores per page
   5.2. Add previous/next buttons
   5.3. Add page numbers
   5.4. Implement AJAX pagination
   5.5. Show total number of scores

6. Add Search Functionality
   6.1. Add search box for player names
   6.2. Implement live search (debounced)
   6.3. Highlight search matches
   6.4. Show "no results" message

7. Add Statistics Section
   7.1. Display total games played
   7.2. Show average score
   7.3. Show highest score ever
   7.4. Display most active player
   7.5. Add chart/graph of scores over time (optional)

8. Add Navigation Links
   8.1. Add leaderboard link to game page
   8.2. Add leaderboard link to main navigation
   8.3. Update layout with consistent navigation

## Expected Outcomes:
- Dedicated leaderboard page accessible
- High scores displayed in table format
- Top 3 scores highlighted
- Filtering by date range works
- Pagination functional
- Search by player name works
- Statistics displayed
- Page is responsive
- Consistent styling with game

## Files Created/Modified:
- Controllers/LeaderboardController.cs (new)
- Views/Leaderboard/Index.cshtml (new)
- wwwroot/css/leaderboard.css (enhanced)
- wwwroot/js/leaderboard.js (new, for client-side functionality)
- Views/Shared/_Layout.cshtml (navigation links)

## Testing Checklist:
- [ ] Leaderboard page loads correctly
- [ ] Scores displayed in order
- [ ] Top 3 scores highlighted
- [ ] Filtering works correctly
- [ ] Pagination works
- [ ] Search functionality works
- [ ] Statistics calculated correctly
- [ ] Navigation links work
- [ ] Page is responsive
- [ ] Works on all browsers
- [ ] Performance is good with many scores

## Completion Notes:
<!-- Update when task is completed -->
