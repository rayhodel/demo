# Task 6 - Implement Player Entity and Controls

Create the player ship entity with movement, shooting, and rendering.

## Status: Pending

## Dependencies: Task 5

## Steps to Complete:

1. Create Player Class
   1.1. Create `wwwroot/js/entities/player.js`
   1.2. Define Player class with properties:
        - position {x, y}
        - width, height
        - speed
        - lives
        - isAlive
        - shootCooldown
        - lastShotTime
   1.3. Implement constructor with initial position

2. Implement Player Movement
   2.1. Add moveLeft() method
   2.2. Add moveRight() method
   2.3. Add boundary checking (stay within canvas)
   2.4. Implement update(deltaTime, inputHandler) method
   2.5. Check for left/right arrow key inputs
   2.6. Update position based on speed and deltaTime

3. Implement Player Shooting
   3.1. Add canShoot() method (check cooldown)
   3.2. Add shoot() method returning bullet object
   3.3. Implement cooldown timer logic
   3.4. Return bullet positioned above player ship
   3.5. Reset cooldown after shooting

4. Implement Player Rendering
   4.1. Add draw(renderer) method
   4.2. Draw rectangle for player ship (temporary)
   4.3. Add visual indicator for respawn invincibility
   4.4. Draw lives indicator on HUD

5. Add Player to Game Engine
   5.1. Import Player class in gameEngine.js
   5.2. Instantiate player in game initialization
   5.3. Call player.update() in game loop
   5.4. Call player.draw() in render cycle
   5.5. Handle player input in update cycle

6. Implement Player Damage and Lives
   6.1. Add takeDamage() method
   6.2. Decrement lives on hit
   6.3. Add respawn() method
   6.4. Implement brief invincibility after respawn
   6.5. Set isAlive = false when lives = 0
   6.6. Trigger game over when player dies

## Expected Outcomes:
- Player ship renders on canvas at bottom center
- Player moves left/right with arrow keys
- Movement bounded by canvas edges
- Player can shoot bullets with spacebar
- Cooldown prevents rapid fire
- Lives system functional
- Player respawns after taking damage

## Files Created/Modified:
- wwwroot/js/entities/player.js (new)
- wwwroot/js/gameEngine.js (player integration)
- wwwroot/js/renderer.js (player rendering support)

## Testing Checklist:
- [ ] Player ship visible at bottom of screen
- [ ] Left arrow moves player left
- [ ] Right arrow moves player right
- [ ] Player cannot move off screen
- [ ] Spacebar creates bullet above player
- [ ] Cooldown prevents spam shooting
- [ ] Lives decrease on damage
- [ ] Player respawns with invincibility
- [ ] Game over triggers at 0 lives

## Completion Notes:
<!-- Update when task is completed -->
