# Task 9 - Implement Collision Detection

Create comprehensive collision detection system for all game entities.

## Status: Pending

## Dependencies: Task 8

## Steps to Complete:

1. Create Collision Utility Module
   1.1. Create `wwwroot/js/collision.js`
   1.2. Implement rectCollision(rect1, rect2) for AABB collision
   1.3. Implement pointInRect(point, rect) for pixel-perfect checks
   1.4. Add getBounds(entity) helper to get collision rectangle
   1.5. Export collision functions

2. Implement Player Bullet Collisions
   2.1. Check player bullets against all enemies
   2.2. On collision:
        - Destroy enemy (set isAlive = false)
        - Deactivate bullet
        - Add points to score
        - Play explosion sound
   2.3. Check player bullets against UFO
   2.4. Check player bullets against bunkers

3. Implement Enemy Bullet Collisions
   3.1. Check enemy bullets against player
   3.2. On collision:
        - Deactivate bullet
        - Call player.takeDamage()
        - Play player hit sound
   3.3. Check enemy bullets against bunkers

4. Implement Enemy-Player Collision
   4.1. Check if any enemy reaches player row
   4.2. Check if any enemy overlaps player position
   4.3. Trigger instant game over

5. Add Collision Detection to Game Loop
   5.1. Create checkCollisions() method in gameEngine.js
   5.2. Call after all entity updates
   5.3. Process all collision types
   5.4. Handle collision responses
   5.5. Update score and lives

6. Optimize Collision Detection
   6.1. Implement spatial partitioning if needed
   6.2. Only check active bullets
   6.3. Only check alive enemies
   6.4. Skip collision checks when invincible
   6.5. Add performance monitoring

## Expected Outcomes:
- Player bullets destroy enemies on hit
- Enemy bullets damage player
- Collision detection is accurate
- Score updates correctly on enemy destruction
- Lives decrease on player hit
- Game over on enemy invasion
- Performance remains at 60 FPS

## Files Created/Modified:
- wwwroot/js/collision.js (new)
- wwwroot/js/gameEngine.js (collision system)
- wwwroot/js/entities/player.js (collision response)
- wwwroot/js/entities/enemy.js (collision response)

## Testing Checklist:
- [ ] Player bullets destroy enemies
- [ ] Correct points awarded per enemy type
- [ ] Enemy bullets damage player
- [ ] Lives decrease on hit
- [ ] Respawn invincibility works
- [ ] Collision detection is pixel-accurate
- [ ] No false collision detections
- [ ] Game over on enemy invasion
- [ ] Performance is acceptable

## Completion Notes:
<!-- Update when task is completed -->
