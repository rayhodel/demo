# Task 10 - Implement Bunker System

Create destructible bunker shields with pixel-level damage system.

## Status: Pending

## Dependencies: Task 9

## Steps to Complete:

1. Create Bunker Class
   1.1. Create `wwwroot/js/entities/bunker.js`
   1.2. Define Bunker class with properties:
        - position {x, y}
        - width, height
        - damageMap (2D array for erosion)
        - isDestroyed
   1.3. Initialize damage map (all pixels intact)

2. Implement Bunker Damage System
   2.1. Add takeDamage(impactX, impactY) method
   2.2. Calculate damage radius around impact point
   2.3. Update damageMap to mark destroyed pixels
   2.4. Check if bunker is completely destroyed
   2.5. Create erosion pattern (circular or realistic)

3. Implement Bunker Rendering
   3.1. Add draw(renderer) method
   3.2. Render bunker shape (classic arc design)
   3.3. Apply damage map to create erosion effect
   3.4. Use canvas pixel manipulation or shapes
   3.5. Draw only intact pixels

4. Create Bunker Manager
   4.1. Add BunkerManager to entityManager.js
   4.2. Create 4 bunkers positioned above player
   4.3. Space bunkers evenly across screen
   4.4. Position at appropriate height
   4.5. Add updateBunkers() method
   4.6. Add drawBunkers(renderer) method

5. Integrate Bunker Collisions
   5.1. Check player bullets against bunkers
   5.2. Check enemy bullets against bunkers
   5.3. Apply damage on collision
   5.4. Deactivate bullet after bunker hit
   5.5. Update collision detection in gameEngine

6. Add to Game Engine
   6.1. Import BunkerManager in gameEngine.js
   6.2. Create bunkers on game initialization
   6.3. Render bunkers in correct layer order
   6.4. Update bunker state if needed

## Expected Outcomes:
- 4 bunkers positioned above player
- Bunkers have classic arc shape
- Bullets erode bunkers on impact
- Damage is cumulative and realistic
- Completely destroyed bunkers disappear
- Bunkers block both player and enemy bullets
- Visual erosion looks natural

## Files Created/Modified:
- wwwroot/js/entities/bunker.js (new)
- wwwroot/js/entityManager.js (BunkerManager)
- wwwroot/js/gameEngine.js (bunker integration)
- wwwroot/js/collision.js (bunker collision)
- wwwroot/js/renderer.js (bunker rendering)

## Testing Checklist:
- [ ] 4 bunkers spawn in correct positions
- [ ] Bunkers have proper shape
- [ ] Player bullets damage bunkers
- [ ] Enemy bullets damage bunkers
- [ ] Damage appears as erosion
- [ ] Destroyed bunkers disappear
- [ ] Bullets stop at bunkers
- [ ] Multiple hits erode bunkers
- [ ] Rendering performance is good

## Completion Notes:
<!-- Update when task is completed -->
