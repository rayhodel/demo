# Space Invaders Game Clone

A modern web-based recreation of the classic Space Invaders arcade game, built with .NET Core MVC and HTML5 Canvas.

## Overview

This project brings the iconic 1978 arcade game to modern web browsers, featuring:
- Classic arcade gameplay with smooth 60 FPS rendering
- Responsive HTML5 Canvas graphics
- Persistent high score tracking with SQL Server
- Wave-based difficulty progression
- Authentic retro sound effects

## Technology Stack

- **.NET 8** - ASP.NET Core MVC framework
- **Entity Framework Core** - Database ORM
- **SQL Server** - Data persistence
- **HTML5 Canvas** - Game rendering
- **JavaScript ES6+** - Client-side game engine
- **CSS3** - Styling and responsive design

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server 2019+ or SQL Server Express/LocalDB
- Modern web browser (Chrome, Firefox, Edge, or Safari)

### Installation

1. **Clone the repository:**
   ```powershell
   git clone https://github.com/rayhodel/demo.git
   cd demo
   ```

2. **Restore dependencies:**
   ```powershell
   dotnet restore
   ```

3. **Update database connection string:**
   - Edit `appsettings.json`
   - Configure your SQL Server connection string

4. **Apply database migrations:**
   ```powershell
   dotnet ef database update
   ```

5. **Run the application:**
   ```powershell
   dotnet run
   ```

6. **Open your browser:**
   - Navigate to `https://localhost:5001`
   - Start playing!

## Gameplay

### Controls
- **Move Left:** Left Arrow or A key
- **Move Right:** Right Arrow or D key
- **Shoot:** Spacebar
- **Pause:** P key (coming soon)

### Objective
- Destroy all alien invaders before they reach the bottom
- Protect your ship from enemy fire
- Use bunkers for cover
- Score points by destroying enemies and UFOs
- Advance through increasingly difficult waves

### Scoring
- Squid aliens (top row): 30 points
- Crab aliens (middle rows): 20 points
- Octopus aliens (bottom rows): 10 points
- Mystery UFO: 50-300 points

## Project Structure

```
SpaceInvaders/
├── Controllers/         # MVC Controllers
├── Models/             # Data models and entities
├── Views/              # Razor views
├── wwwroot/            # Static assets
│   ├── css/           # Stylesheets
│   ├── js/            # Game engine JavaScript
│   ├── images/        # Sprites and graphics
│   └── sounds/        # Audio files
├── Data/              # Database context
└── docs/              # Documentation
```

## Development

### Running Tests
```powershell
dotnet test
```

### Database Migrations
```powershell
# Create new migration
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update
```

### Hot Reload
```powershell
dotnet watch run
```

## Documentation

For detailed documentation, see:
- [Complete Game Documentation](docs/spec.md)
- [Changelog](docs/CHANGELOG.md)
- [Implementation Tasks](tasks/)

## Roadmap

### Phase 1 (Current)
- ✅ Core gameplay mechanics
- ✅ High score persistence
- 🔲 Sound effects and music
- 🔲 Wave progression

### Phase 2
- Leaderboard system
- Difficulty settings
- Pause functionality
- Mobile controls

### Phase 3
- Multiplayer mode (SignalR)
- Achievements system
- Custom themes
- Game modes (endless, timed, boss battles)

## Contributing

This is a personal learning project, but suggestions and feedback are welcome!

## License

MIT License - feel free to use this project for learning purposes.

## Acknowledgments

- Original Space Invaders created by Tomohiro Nishikado (1978)
- Inspired by the golden age of arcade gaming

---

**Status:** 🚧 In Development  
**Version:** 0.1.0  
**Last Updated:** November 19, 2025
