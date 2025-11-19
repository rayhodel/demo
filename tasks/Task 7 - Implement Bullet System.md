# Task 7 - Implement Bullet System

Create bullet entities with movement, collision detection, and object pooling for performance.

## Status: Pending

## Dependencies: Task 6

## Steps to Complete:

1. Create Bullet Class
   1.1. Create `wwwroot/js/entities/bullet.js`
   1.2. Define Bullet class with properties:
        - position {x, y}
        - velocity {x, y}
        - width, height
        - isActive
        - owner (PLAYER or ENEMY)
   1.3. Implement constructor

2. Implement Bullet Behavior
   2.1. Add update(deltaTime) method
   2.2. Move bullet based on velocity and deltaTime
   2.3. Check if bullet is off-screen
   2.4. Deactivate bullet when off-screen
   2.5. Add draw(renderer) method
   2.6. Render bullet as rectangle

3. Create Bullet Manager (entityManager.js)
   3.1. Create BulletManager class
   3.2. Implement object pooling for bullets
   3.3. Add createBullet(x, y, velocity, owner) method
   3.4. Maintain active bullets array
   3.5. Implement updateBullets(deltaTime) method
   3.6. Implement drawBullets(renderer) method
   3.7. Add recycleBullet(bullet) for pooling

4. Integrate Bullet System with Game Engine
   4.1. Import BulletManager in gameEngine.js
   4.2. Instantiate BulletManager
   4.3. Call createBullet when player shoots
   4.4. Update all bullets in game loop
   4.5. Render all bullets in render cycle

5. Add Bullet Collision Detection Preparation
   5.1. Add getBounds() method to Bullet class
   5.2. Create collision detection utility functions
   5.3. Add checkCollision(bullet, entity) stub
   5.4. Prepare for enemy collision in next task

## Expected Outcomes:
- Bullets spawn when player shoots
- Bullets move upward at correct speed
- Bullets disappear at screen edge
- Object pooling reduces garbage collection
- Multiple bullets can exist simultaneously
- Bullet rendering is smooth

## Files Created/Modified:
- wwwroot/js/entities/bullet.js (new)
- wwwroot/js/entityManager.js (bullet pooling)
- wwwroot/js/gameEngine.js (bullet system integration)
- wwwroot/js/renderer.js (bullet rendering)

## Testing Checklist:
- [ ] Bullets spawn at player position
- [ ] Bullets move upward smoothly
- [ ] Bullets disappear at top of screen
- [ ] Multiple bullets work simultaneously
- [ ] No memory leaks from bullet creation
- [ ] Fire rate cooldown works correctly

## Completion Notes:
<!-- Update when task is completed -->
