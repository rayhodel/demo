# Task 11 - Implement UFO (Mystery Ship)

Create the bonus UFO that periodically flies across the top of the screen.

## Status: Pending

## Dependencies: Task 9

## Steps to Complete:

1. Create UFO Class
   1.1. Create `wwwroot/js/entities/ufo.js`
   1.2. Define UFO class with properties:
        - position {x, y}
        - velocity {x, y}
        - width, height
        - isActive
        - pointValue (50-300, randomized)
        - direction (LEFT or RIGHT)
   1.3. Implement constructor

2. Implement UFO Behavior
   2.1. Add update(deltaTime) method
   2.2. Move horizontally across screen
   2.3. Deactivate when off-screen
   2.4. Randomize starting direction
   2.5. Randomize point value on spawn

3. Create UFO Manager
   3.1. Add UFOManager to entityManager.js
   3.2. Add spawnTimer property
   3.3. Implement checkSpawn() method
   3.4. Randomize spawn intervals (15-30 seconds)
   3.5. Spawn UFO at screen edge
   3.6. Only one UFO active at a time

4. Implement UFO Rendering
   4.1. Add draw(renderer) method
   4.2. Draw UFO shape (classic design)
   4.3. Add simple animation or color change
   4.4. Display point value on destruction (temporary)

5. Implement UFO Audio
   5.1. Add UFO movement sound (looping)
   5.2. Play sound when UFO spawns
   5.3. Stop sound when UFO destroyed or off-screen
   5.4. Add destruction sound effect

6. Integrate UFO Collisions
   6.1. Check player bullets against UFO
   6.2. On hit:
        - Award randomized points
        - Display point value briefly
        - Deactivate UFO
        - Play destruction sound
   6.3. Update collision detection in gameEngine

7. Add to Game Engine
   7.1. Import UFOManager in gameEngine.js
   7.2. Initialize UFO system
   7.3. Update UFO in game loop
   7.4. Render UFO above enemy formation
   7.5. Handle UFO spawn timing

## Expected Outcomes:
- UFO spawns periodically (15-30 sec intervals)
- UFO flies across top of screen
- UFO has distinctive appearance
- UFO sound plays when active
- Player can shoot UFO for bonus points
- Point value (50-300) displayed on hit
- Only one UFO active at a time

## Files Created/Modified:
- wwwroot/js/entities/ufo.js (new)
- wwwroot/js/entityManager.js (UFOManager)
- wwwroot/js/gameEngine.js (UFO integration)
- wwwroot/js/collision.js (UFO collision)
- wwwroot/js/audioManager.js (UFO sounds)
- wwwroot/js/renderer.js (UFO rendering)

## Testing Checklist:
- [ ] UFO spawns randomly every 15-30 seconds
- [ ] UFO flies across screen at correct height
- [ ] UFO sound plays when active
- [ ] UFO can be shot by player
- [ ] Point value randomized (50-300)
- [ ] Bonus points displayed on hit
- [ ] Destruction sound plays
- [ ] Only one UFO at a time
- [ ] UFO doesn't spawn during game over

## Completion Notes:
<!-- Update when task is completed -->
