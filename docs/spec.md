# Space Invaders Game Clone - Documentation

## Project Overview

A web-based Space Invaders game clone built with .NET Core MVC, featuring classic arcade gameplay with modern web technologies. The game uses HTML5 Canvas for rendering, JavaScript for the game engine, and ASP.NET Core MVC for server-side functionality including high score persistence.

**Project Type:** Web Application  
**Framework:** .NET 8 (ASP.NET Core MVC)  
**Client Technologies:** HTML5 Canvas, JavaScript ES6+, CSS3  
**Database:** SQL Server with Entity Framework Core  
**Target Platform:** Modern web browsers (Chrome, Firefox, Edge, Safari)

---

## Game Requirements

### Core Gameplay Features

#### 1. Player Controls
- **Movement:** Left/Right arrow keys or A/D keys to move the player ship horizontally
- **Shooting:** Spacebar to fire bullets upward
- **Constraints:** Player ship confined to bottom portion of screen
- **Fire Rate:** Cooldown period between shots to prevent spamming

#### 2. Enemy Behavior
- **Formation:** 5 rows x 11 columns grid of alien enemies (55 total)
- **Movement Pattern:** 
  - Move horizontally across screen as a group
  - Step down one row when reaching screen edge
  - Direction reversal at screen boundaries
  - Speed increases as enemies are destroyed
- **Enemy Types:** 
  - Top row (1 row): 30 points - Squid aliens
  - Middle rows (2 rows): 20 points - Crab aliens  
  - Bottom rows (2 rows): 10 points - Octopus aliens
- **Shooting:** Random enemies periodically fire bullets downward

#### 3. Defensive Structures
- **Bunkers:** 4 destructible shields positioned above player
- **Damage System:** Bunkers erode gradually from bullet impacts
- **Protection:** Shields block both player and enemy bullets

#### 4. Mystery Ship (UFO)
- **Appearance:** Periodically flies across top of screen
- **Points:** 50-300 points (randomized bonus)
- **Speed:** Faster than enemy formation
- **Sound:** Distinctive audio cue when present

#### 5. Collision Detection
- **Player Bullets:** Destroy enemies, damage bunkers, destroy UFO
- **Enemy Bullets:** Destroy player, damage bunkers
- **Enemy Invasion:** Game over if enemies reach player row
- **Precision:** Pixel-perfect collision detection for fair gameplay

#### 6. Scoring System
- Point values for each enemy type and UFO
- Score multiplier for consecutive hits
- High score tracking (session and all-time)
- Display current score, high score, and lives remaining

#### 7. Lives and Game Over
- **Starting Lives:** 3 lives per game
- **Life Loss:** Hit by enemy bullet or enemy reaches bottom
- **Respawn:** Brief invincibility period after respawn
- **Game Over Conditions:** All lives lost or enemies reach player level

#### 8. Wave/Level System
- New wave spawns after all enemies destroyed
- Enemies start lower and move faster each wave
- Increasing difficulty progression
- Level counter displayed

### Technical Requirements

#### Browser Support
- **Primary:** Chrome 90+, Firefox 88+, Edge 90+, Safari 14+
- **Resolution:** Responsive design supporting 1024x768 minimum
- **Performance:** 60 FPS target frame rate
- **Audio:** Web Audio API for sound effects and music

#### .NET Requirements
- **.NET Version:** .NET 8 SDK
- **Database:** SQL Server 2019+ or SQL Server Express
- **ORM:** Entity Framework Core 8.x
- **Dependencies:** 
  - Microsoft.AspNetCore.Mvc
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools

#### Development Environment
- **IDE:** Visual Studio 2022 or VS Code with C# extension
- **Version Control:** Git
- **Package Manager:** NuGet
- **Build System:** MSBuild / dotnet CLI

### Optional/Future Features

#### Phase 2 Enhancements
- **Leaderboard:** Global high scores with player names
- **Difficulty Levels:** Easy, Normal, Hard modes
- **Power-ups:** Special weapons, shields, extra lives
- **Sound Toggle:** Mute/unmute controls
- **Pause Functionality:** Pause and resume game
- **Mobile Support:** Touch controls for mobile devices

#### Phase 3 Enhancements
- **Multiplayer:** Co-op or competitive modes using SignalR
- **Achievements:** Unlock system for milestones
- **Visual Themes:** Classic, modern, or custom color schemes
- **Game Modes:** Endless mode, timed challenges, boss battles
- **Replay System:** Save and watch game replays

---

## Architecture

### MVC Structure

#### Controllers

**GameController.cs**
- `Index()` - Main game page view
- `StartGame()` - Initialize new game session
- `SaveScore(int score)` - Persist player score to database
- `GetHighScores(int count)` - Retrieve top scores
- `GetGameState()` - Return current game configuration

**LeaderboardController.cs**
- `Index()` - Display high scores page
- `GetTopScores(int limit)` - API endpoint for leaderboard data

#### Models

**Player.cs**
```csharp
- Position { X, Y }
- Lives
- Score
- IsAlive
- Methods: Move(), Shoot(), TakeDamage()
```

**Enemy.cs**
```csharp
- Position { X, Y }
- Type (Squid/Crab/Octopus)
- PointValue
- IsAlive
- Methods: Move(), Shoot()
```

**Bullet.cs**
```csharp
- Position { X, Y }
- Velocity { X, Y }
- Owner (Player/Enemy)
- IsActive
- Methods: Update(), CheckCollision()
```

**Bunker.cs**
```csharp
- Position { X, Y }
- DamageMap (2D array for erosion)
- Health
- Methods: TakeDamage(position), IsDestroyed()
```

**UFO.cs**
```csharp
- Position { X, Y }
- Speed
- PointValue
- IsActive
- Methods: Update(), Spawn()
```

**GameSession.cs** (Database Entity)
```csharp
- Id (PK)
- PlayerName
- Score
- Level
- DatePlayed
- Duration
```

**HighScore.cs** (Database Entity)
```csharp
- Id (PK)
- PlayerName
- Score
- Level
- DateAchieved
```

#### Views

**Game/Index.cshtml**
- Main game canvas container
- HUD (score, lives, level display)
- Game over overlay
- Start/restart buttons
- References to game JavaScript files

**Leaderboard/Index.cshtml**
- High scores table
- Filters and sorting options
- Navigation back to game

**Shared/_Layout.cshtml**
- Common layout structure
- Navigation menu
- Responsive design framework

### Client-Side Architecture

#### JavaScript Modules

**game.js** - Main game orchestrator
- Game loop management (requestAnimationFrame)
- State management (menu, playing, paused, gameOver)
- Initialization and cleanup

**gameEngine.js** - Core game logic
- Update cycle for all entities
- Collision detection system
- Wave progression logic
- Difficulty scaling

**renderer.js** - Canvas rendering
- Draw player, enemies, bullets, bunkers, UFO
- HUD rendering (score, lives, level)
- Sprite management and animation
- Particle effects

**inputHandler.js** - User input
- Keyboard event listeners
- Key state tracking
- Input buffering for smooth controls

**entityManager.js** - Entity management
- Object pooling for bullets
- Entity creation and destruction
- Position and state tracking

**audioManager.js** - Sound system
- Sound effect playback
- Background music loop
- Volume controls
- Web Audio API implementation

**api.js** - Server communication
- AJAX calls to controllers
- Score submission
- High score retrieval
- Error handling

#### Asset Structure (wwwroot/)

```
wwwroot/
├── css/
│   ├── game.css - Game-specific styles
│   └── leaderboard.css - Leaderboard styles
├── js/
│   ├── game.js - Main game file
│   ├── gameEngine.js - Core logic
│   ├── renderer.js - Canvas rendering
│   ├── inputHandler.js - Input handling
│   ├── entityManager.js - Entity management
│   ├── audioManager.js - Sound management
│   └── api.js - API communication
├── images/
│   ├── sprites/
│   │   ├── player.png - Player ship sprite
│   │   ├── enemies.png - Enemy sprite sheet
│   │   ├── ufo.png - UFO sprite
│   │   └── bunker.png - Bunker sprite
│   └── ui/
│       ├── life-icon.png - Lives indicator
│       └── background.png - Game background
└── sounds/
    ├── shoot.wav - Player shoot sound
    ├── explosion.wav - Enemy destruction
    ├── ufo.wav - UFO sound loop
    ├── player-death.wav - Player death sound
    └── game-over.wav - Game over sound
```

### Database Schema

**GameSessions Table**
```sql
CREATE TABLE GameSessions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlayerName NVARCHAR(50) NOT NULL,
    Score INT NOT NULL,
    Level INT NOT NULL,
    DatePlayed DATETIME2 NOT NULL DEFAULT GETDATE(),
    Duration INT NULL, -- seconds
    IsCompleted BIT NOT NULL DEFAULT 0
);
```

**HighScores Table**
```sql
CREATE TABLE HighScores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlayerName NVARCHAR(50) NOT NULL,
    Score INT NOT NULL,
    Level INT NOT NULL,
    DateAchieved DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT UQ_HighScore UNIQUE (PlayerName, Score)
);

CREATE INDEX IX_HighScores_Score DESC ON HighScores(Score);
```

### Data Flow

1. **Game Initialization:**
   - User navigates to `/Game/Index`
   - View loads game canvas and JavaScript modules
   - Client-side game engine initializes
   - Game state set to "ready to start"

2. **Gameplay Loop:**
   - JavaScript game loop runs at 60 FPS
   - Input handler captures player commands
   - Game engine updates entity positions
   - Collision detection checks all interactions
   - Renderer draws current frame to canvas
   - Audio manager plays sound effects

3. **Score Persistence:**
   - Player completes game or loses all lives
   - JavaScript calls API endpoint `/Game/SaveScore`
   - Server validates and saves to database
   - Client retrieves updated high scores
   - Leaderboard updates if score qualifies

4. **High Score Display:**
   - User navigates to `/Leaderboard/Index`
   - Controller queries top scores from database
   - View renders formatted leaderboard table

---

## Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SpaceInvadersDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "GameSettings": {
    "CanvasWidth": 800,
    "CanvasHeight": 600,
    "PlayerSpeed": 5,
    "PlayerBulletSpeed": 7,
    "EnemyBulletSpeed": 4,
    "InitialEnemySpeed": 1,
    "EnemySpeedIncrease": 0.1,
    "EnemyColumns": 11,
    "EnemyRows": 5,
    "BunkerCount": 4,
    "StartingLives": 3,
    "FireCooldown": 500,
    "MaxHighScores": 10
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Game Constants (JavaScript)

```javascript
// Game canvas dimensions
const CANVAS_WIDTH = 800;
const CANVAS_HEIGHT = 600;

// Player settings
const PLAYER_WIDTH = 40;
const PLAYER_HEIGHT = 30;
const PLAYER_SPEED = 5;
const PLAYER_BULLET_SPEED = 7;
const FIRE_COOLDOWN = 500; // milliseconds

// Enemy settings
const ENEMY_WIDTH = 32;
const ENEMY_HEIGHT = 24;
const ENEMY_COLS = 11;
const ENEMY_ROWS = 5;
const ENEMY_SPACING_X = 50;
const ENEMY_SPACING_Y = 40;
const INITIAL_ENEMY_SPEED = 1;
const ENEMY_DESCENT = 20;

// Scoring
const POINTS_SQUID = 30;
const POINTS_CRAB = 20;
const POINTS_OCTOPUS = 10;
const POINTS_UFO_MIN = 50;
const POINTS_UFO_MAX = 300;
```

---

## Build and Deployment

### Local Development Setup

#### Prerequisites
```powershell
# Check .NET SDK version
dotnet --version  # Should be 8.0.x or higher

# Check SQL Server availability
sqlcmd -S (localdb)\mssqllocaldb -Q "SELECT @@VERSION"
```

#### Initial Project Setup
```powershell
# Navigate to project directory
cd c:\Users\hodel\projects\demo

# Create .NET MVC project
dotnet new mvc -n SpaceInvaders -o .

# Add Entity Framework Core packages
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

# Restore packages
dotnet restore

# Create database migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Running the Application
```powershell
# Build the project
dotnet build

# Run in development mode
dotnet run

# Run with hot reload
dotnet watch run
```

Default URL: `https://localhost:5001` or `http://localhost:5000`

### Database Migrations

```powershell
# Create new migration
dotnet ef migrations add <MigrationName>

# Apply migrations to database
dotnet ef database update

# Rollback to specific migration
dotnet ef database update <MigrationName>

# Remove last migration
dotnet ef migrations remove

# Generate SQL script
dotnet ef migrations script
```

### Testing

#### Unit Testing Setup
```powershell
# Create test project
dotnet new xunit -n SpaceInvaders.Tests -o tests

# Add reference to main project
cd tests
dotnet add reference ..\SpaceInvaders.csproj

# Add testing packages
dotnet add package Moq
dotnet add package FluentAssertions

# Run tests
dotnet test
```

#### Testing Strategy
- **Unit Tests:** Game logic, collision detection, scoring calculations
- **Integration Tests:** Database operations, API endpoints
- **Manual Testing:** Gameplay mechanics, browser compatibility

### Production Deployment

#### Build for Production
```powershell
# Publish optimized build
dotnet publish -c Release -o ./publish

# The publish folder contains all files needed for deployment
```

#### Deployment Targets
- **Azure App Service:** Recommended for scalability
- **IIS:** Traditional Windows Server hosting
- **Docker:** Containerized deployment
- **Linux with Kestrel:** Cross-platform option

#### Production Configuration
- Update connection string in `appsettings.Production.json`
- Configure HTTPS certificates
- Set up application logging
- Enable CORS if needed for CDN assets
- Configure compression for static assets

---

## Development Guidelines

### Code Organization

- **Controllers:** Thin controllers focused on HTTP concerns
- **Services:** Business logic in separate service classes
- **Repository Pattern:** Data access abstraction for EF Core
- **Dependency Injection:** Use built-in DI container
- **Async/Await:** Use for all database operations

### JavaScript Best Practices

- **ES6 Modules:** Use import/export for code organization
- **Class-based Entities:** Use classes for game entities
- **Constants:** Define magic numbers as named constants
- **Comments:** Document complex game logic
- **Error Handling:** Try-catch for API calls

### Performance Optimization

- **Object Pooling:** Reuse bullet objects instead of creating new ones
- **Sprite Sheets:** Use sprite atlases to reduce HTTP requests
- **RequestAnimationFrame:** Use for smooth 60 FPS rendering
- **Debouncing:** Limit API calls for score updates
- **Minification:** Minify CSS and JavaScript for production

### Version Control

- **Branching Strategy:** Feature branches merged to main
- **Commit Messages:** Descriptive messages following conventions
- **Pull Requests:** Code review before merging
- **.gitignore:** Exclude bin/, obj/, .vs/, appsettings.Development.json

---

## Troubleshooting

### Common Issues

**Canvas not rendering:**
- Check browser console for JavaScript errors
- Verify canvas element has proper width/height
- Ensure game.js is loaded after DOM ready

**Database connection errors:**
- Verify SQL Server LocalDB is running
- Check connection string in appsettings.json
- Ensure migrations have been applied

**Performance issues:**
- Monitor FPS in browser dev tools
- Check for memory leaks in object creation
- Optimize sprite rendering with caching

**Audio not playing:**
- Verify browser autoplay policies
- Check audio files are in correct format
- Ensure user interaction before playing audio

---

## Future Considerations

### Scalability
- Implement caching for high scores (Redis)
- Use CDN for static assets
- Add SignalR for real-time multiplayer

### Analytics
- Track player engagement metrics
- Monitor game completion rates
- Analyze difficulty balance from player data

### Accessibility
- Keyboard alternatives to arrow keys
- Color blind friendly color schemes
- Screen reader compatibility for menus

---

## References

### External Documentation
- [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [HTML5 Canvas API](https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API)
- [Web Audio API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Audio_API)
- [Original Space Invaders Game Design](https://en.wikipedia.org/wiki/Space_Invaders)

### Internal Documentation
- See `docs/CHANGELOG.md` for version history
- See `docs/updates/` for specific feature documentation
- See `tasks/` for implementation task breakdown

---

**Document Version:** 1.0  
**Last Updated:** November 19, 2025  
**Author:** GitHub Copilot (with rayhodel)
