# Task 8 - Implement Enemy System

Create enemy entities with formation, movement patterns, and shooting behavior.

## Status: Pending

## Dependencies: Task 7

## Steps to Complete:

1. Create Enemy Class
   1.1. Create `wwwroot/js/entities/enemy.js`
   1.2. Define Enemy class with properties:
        - position {x, y}
        - type (SQUID, CRAB, OCTOPUS)
        - width, height
        - isAlive
        - pointValue
        - animationFrame
   1.3. Implement constructor
   1.4. Add getPointValue() based on type

2. Create Enemy Manager
   2.1. Create EnemyManager class in entityManager.js
   2.2. Define formation layout (11 cols x 5 rows)
   2.3. Add createFormation() method
   2.4. Position enemies in grid pattern
   2.5. Assign enemy types by row:
        - Row 0: Squid (30 pts)
        - Rows 1-2: Crab (20 pts)
        - Rows 3-4: Octopus (10 pts)

3. Implement Enemy Movement
   3.1. Add direction property (LEFT or RIGHT)
   3.2. Add speed property
   3.3. Implement moveFormation(deltaTime) method
   3.4. Move all enemies horizontally together
   3.5. Check if any enemy reaches screen edge
   3.6. On edge: reverse direction and move down
   3.7. Increase speed as enemies are destroyed

4. Implement Enemy Shooting
   4.1. Add shootingTimer to EnemyManager
   4.2. Randomly select enemy to shoot
   4.3. Create enemy bullet moving downward
   4.4. Add to bullet manager with ENEMY owner
   4.5. Adjust shooting frequency based on difficulty

5. Implement Enemy Rendering
   5.1. Add draw(renderer) method to Enemy class
   5.2. Draw enemy based on type (different colors/shapes)
   5.3. Add simple animation (2 frames alternating)
   5.4. Render all enemies in formation

6. Integrate with Game Engine
   6.1. Import EnemyManager in gameEngine.js
   6.2. Create enemy formation on game start
   6.3. Update enemies in game loop
   6.4. Render enemies in render cycle
   6.5. Check if enemies reach player level (game over)

7. Add Wave System
   7.1. Track current wave number
   7.2. Detect when all enemies destroyed
   7.3. Create new formation for next wave
   7.4. Start formation lower and faster each wave
   7.5. Update level display on HUD

## Expected Outcomes:
- 55 enemies in formation (11x5 grid)
- Enemies move left/right as group
- Formation descends and reverses at edges
- Enemies shoot bullets randomly
- Speed increases as enemies destroyed
- Different enemy types with point values
- Wave system spawns new formations

## Files Created/Modified:
- wwwroot/js/entities/enemy.js (new)
- wwwroot/js/entityManager.js (EnemyManager)
- wwwroot/js/gameEngine.js (enemy integration)
- wwwroot/js/renderer.js (enemy rendering)

## Testing Checklist:
- [ ] 55 enemies spawn in correct formation
- [ ] Enemies move left/right in sync
- [ ] Formation descends at screen edges
- [ ] Direction reverses correctly
- [ ] Enemies shoot bullets downward
- [ ] Speed increases as enemies die
- [ ] New wave spawns when all destroyed
- [ ] Enemy types have correct point values
- [ ] Game over when enemies reach bottom

## Completion Notes:
<!-- Update when task is completed -->
