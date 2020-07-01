# Spite Framework
![.NET Core](https://github.com/greenstack/spite-framework/workflows/.NET%20Core/badge.svg)

## Overview
The Spite Framework is a C# library meant to simplify designing and implementing turn-based gameplay. The hope is that through the Spite 
Framework, developers can quickly develop all  kinds of turn-based games, from RPGs to board games.

These are the core classes/interfaces that make this possible:
 - **Arena**: This keeps track of all the teams and the team manager to keep battles organized effectively. An `ArenaBuilder` is provided to build an Arena.
 - **ITurnManager**: Helps keep track of turns and the phases in the game through `ITurnPhase` interface implementations.
 - **ITeam**: Keeps track of the entities and its current standing in the battle. A `TeamBuilder` class (implemented generically) can help build teams to place in arenas.
 - **IEntity**: The smallest unit provided by the framework. The interface is very open ended, to allow for a large number of applications.
 
## Getting Started
To get started with Spite, you'll need to have a good understanding of Arenas, Turn Managers, and Teams. Entities are very barebones, and mostly implementation specific. This section shows how to get started with these elements, to help set you up for a basic turn-based game system.

Examples can also be found in the [examples](examples) directory.
 
### Arenas
Arenas are the highest level unit of control in the framework. They manage the teams and turns of a battle.
 
You can build Arenas with the ArenaBuilder:
```csharp
using Spite;

...

// Set up the teams and the TurnManager
Arena arena = new ArenaBuilder()
    .SetArenaName("Example") // Optional - Arenas don't necessarily need names
    .SetTurnManager(...)     // This sets the TurnManager that the Arena will use to manage the battle
    .SetSideCount(2)         // This sets the number of sides/teams playing in the game
    // Here, you would call "addTeam" and pass in the teams you want to add
    .Finish();               // This finalizes the arena you'll get
```
The `ArenaBuilder` allows you to create scenarios in a dynamic way. For example, when a battle starts, your method using the `ArenaBuilder` could
ask for a custom `BattleDefinition` object with a `List<Team> Sides` property:
```csharp
ArenaBuilder builder = new ArenaBuilder();

int sides = battleDefinition.Sides.Count();

builder.SetSideCount(sides);
foreach (var team in battleDefinition.Sides) {
    builder.AddTeam(team);
}
```
This flexibility allows developers to create some interface for designers to create unique and varied battles. Designers can create a battle scenario with a tool, saving it to some format; developers read in this format and pass it to the `ArenaBuilder`. This can greatly assist in iterating quickly, without having to recode various components.

### Teams
Teams are one of the most important elements of a game. To reflect this, the Spite Framework has a `TeamBuilder` object provided to help produce teams in a dynamic way. The TeamBuilder has template methods to allow you to build and retrieve a specific type of team, built to your game's specifications.

The following example uses hypothetical `GameTeam` and `GameEntity` types to build up a team:
```csharp
TeamBuilder builder = new TeamBuilder();
builder.Start<GameTeam>()
  .SetTeamSize(2) // For teams with only two entities on it
  .AddEntity(new GameEntity(...))
  .AddEntity(new GameEntity(...))
  .Finish<GameTeam>();
```
TeamBuilders are useful for creating dynamic or user-defined teams. For example, an RPG that gives the player several characters to use, but they can only bring a few of them into any given battle, building the team either on the fly when a battle begins or reconstructing the team when the player changes their party members.
