# Task 2 - Create Database Models and Context

Define Entity Framework Core models for game data persistence and configure the database context.

## Status: Pending

## Dependencies: Task 1

## Steps to Complete:

1. Create Data Folder and DbContext
   1.1. Create `Data/` folder in project root
   1.2. Create `Data/SpaceInvadersDbContext.cs`
   1.3. Inherit from DbContext
   1.4. Configure connection string in constructor

2. Create Entity Models
   2.1. Create `Models/GameSession.cs` with properties:
        - Id (int, PK)
        - PlayerName (string, required)
        - Score (int)
        - Level (int)
        - DatePlayed (DateTime)
        - Duration (int, nullable)
        - IsCompleted (bool)
   2.2. Create `Models/HighScore.cs` with properties:
        - Id (int, PK)
        - PlayerName (string, required)
        - Score (int)
        - Level (int)
        - DateAchieved (DateTime)

3. Configure DbContext
   3.1. Add DbSet<GameSession> GameSessions property
   3.2. Add DbSet<HighScore> HighScores property
   3.3. Override OnModelCreating for table configurations
   3.4. Add unique constraint on HighScore (PlayerName, Score)
   3.5. Add index on HighScore.Score (descending)

4. Register DbContext in Program.cs
   4.1. Add DbContext service with SQL Server provider
   4.2. Configure connection string from appsettings.json
   4.3. Enable sensitive data logging in development mode

5. Create Initial Migration
   5.1. Run `dotnet ef migrations add InitialCreate`
   5.2. Verify migration file generated in Migrations/ folder
   5.3. Review Up() and Down() methods
   5.4. Run `dotnet ef database update`
   5.5. Verify database and tables created in SQL Server

## Expected Outcomes:
- Database models defined
- DbContext configured
- Migrations created and applied
- Database created with correct schema

## Files Created/Modified:
- Data/SpaceInvadersDbContext.cs
- Models/GameSession.cs
- Models/HighScore.cs
- Program.cs (DbContext registration)
- Migrations/[timestamp]_InitialCreate.cs

## Completion Notes:
<!-- Update when task is completed -->
