# Task 5 - Implement Game Engine Core

Create the core game engine with game loop, state management, and basic rendering setup.

## Status: Pending

## Dependencies: Task 3, Task 4

## Steps to Complete:

1. Implement Game State Management (game.js)
   1.1. Define game states enum (MENU, PLAYING, PAUSED, GAME_OVER)
   1.2. Create Game class with state property
   1.3. Implement initialization method
   1.4. Add state transition methods
   1.5. Set up canvas context reference
   1.6. Add DOM element references (score, lives, level displays)

2. Implement Game Loop (gameEngine.js)
   2.1. Create GameEngine class
   2.2. Implement requestAnimationFrame loop
   2.3. Calculate delta time between frames
   2.4. Add update() method for game logic
   2.5. Add render() method calling renderer
   2.6. Implement start(), stop(), pause(), resume() methods
   2.7. Add FPS tracking for performance monitoring

3. Implement Basic Renderer (renderer.js)
   3.1. Create Renderer class with canvas context
   3.2. Implement clear() method to clear canvas
   3.3. Add drawRect() helper for debugging
   3.4. Add drawText() for HUD text
   3.5. Implement renderHUD() method (score, lives, level)
   3.6. Add renderGameOver() method for overlay
   3.7. Create coordinate conversion utilities

4. Implement Input Handler (inputHandler.js)
   4.1. Create InputHandler class
   4.2. Add keyboard event listeners (keydown, keyup)
   4.3. Maintain key state map (pressed keys)
   4.4. Implement isKeyPressed(key) method
   4.5. Add key code constants (ARROW_LEFT, ARROW_RIGHT, SPACE, etc.)
   4.6. Handle key repeat prevention for shooting
   4.7. Add cleanup method to remove event listeners

5. Wire Up Modules
   5.1. Import all modules in game.js
   5.2. Initialize all systems on page load
   5.3. Connect game engine to renderer
   5.4. Connect input handler to game engine
   5.5. Add start button click handler
   5.6. Test basic game loop runs at 60 FPS

6. Add Configuration Constants
   6.1. Create constants.js or add to game.js
   6.2. Define CANVAS_WIDTH, CANVAS_HEIGHT
   6.3. Define game speed constants
   6.4. Define color palette
   6.5. Export constants for use in other modules

## Expected Outcomes:
- Functional game loop running at 60 FPS
- State management working (can start/stop game)
- Input handler capturing keyboard events
- Basic HUD rendering (with placeholder data)
- All modules properly connected

## Files Created/Modified:
- wwwroot/js/game.js (complete implementation)
- wwwroot/js/gameEngine.js (complete implementation)
- wwwroot/js/renderer.js (basic rendering)
- wwwroot/js/inputHandler.js (complete implementation)
- Views/Game/Index.cshtml (script references)

## Testing Checklist:
- [ ] Game starts when button clicked
- [ ] Canvas clears and renders each frame
- [ ] FPS counter shows ~60 FPS
- [ ] Keyboard inputs detected
- [ ] HUD displays placeholder values
- [ ] No console errors

## Completion Notes:
<!-- Update when task is completed -->
