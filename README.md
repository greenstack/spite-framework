# Spite Framework
![.NET](https://github.com/greenstack/spite-framework/workflows/.NET/badge.svg)
[![Spite on fuget.org](https://www.fuget.org/packages/Spite/badge.svg)](https://www.fuget.org/packages/Spite)

The Spite Framework is a C# library meant to simplify designing and
implementing turn-based gameplay. The hope is that through the Spite Framework,
developers can quickly develop all  kinds of turn-based games, from RPGs to
board games. To do this, Spite is centered on a few core design pillars:
 - Spite represents the model. The view and the controller are the game
 developer's responsibility.
 - The entry point for all Spite transactions are through an Arena, which acts
 as a [facade](https://en.wikipedia.org/wiki/Facade_pattern) to the underlying
 structure.
 - Developers should be able to access and mess with the underlying structure
 should they need to.
 - Be compatible with as many C# game engines and frameworks as possible while
 also being as portable as possible.

## Overview
These are the core classes/interfaces that make this possible:
 - **Arena**: This keeps track of all the teams and the team manager to keep battles organized effectively. An `ArenaBuilder` is provided to build an Arena.
 - **ITurnManager**: Helps keep track of turns and the phases in the game through `ITurnPhase` interface implementations.
 - **ITeam**: Keeps track of the team members and its current standing in the battle. A `TeamBuilder` class (implemented generically) can help build teams to place in arenas.
 - **ITeammate**: The smallest unit provided by the framework. The interface is very open ended to allow for a large number of applications.

### Installing and Building
Currently, the best way to integrate Spite into your code is to clone the repository and run `dotnet build` from the `src` directory. You can copy the resulting library and XML documentation to your project.

Hopefully, Spite will eventually be available as a NuGet package.

## Getting Started
To get started with Spite, you'll need to have a good understanding of Arenas, Turn Managers, and Teams. Entities are very barebones, and mostly implementation specific. This section shows how to get started with these elements, to help set you up for a basic turn-based game system.

A battleship example can also be found in the [examples](examples) directory.
(These will someday be moved into a specialized "examples" repository.)
 
### Arenas
**DISCLAIMER:** This section is still a work in progress (and very out of date). Looking at the example code and the source code itself is probably the best way to understand what's going on here.

Arenas are the highest level unit of control in the framework. They manage the teams and turns of a battle.
 
You can build Arenas with the ArenaBuilder:
```csharp
using Spite;

...

// Set up the teams and the TurnManager
Arena arena = new ArenaBuilder()
    .SetArenaName("Example") // Optional - Arenas don't necessarily need names
    .SetTurnManager(...)     // This sets the TurnManager that the Arena will use to manage the battle
    .SetTeamCount(2)         // This sets the number of sides/teams playing in the game
    // Here, you would call "addTeam" and pass in the teams you want to add
    .Finish();               // This finalizes the arena you'll get
```
The `ArenaBuilder` allows you to create scenarios in a dynamic way. For example, when a battle starts, your method using the `ArenaBuilder` could
ask for a custom `BattleDefinition` object with a `List<Team> Sides` property:
```csharp
ArenaBuilder builder = new ArenaBuilder();

int teamCount = battleDefinition.Teams.Count();

builder.SetTeamCount(teamCount);
foreach (var team in battleDefinition.Teams) {
    builder.AddTeam(team);
}
```
This flexibility allows developers to create some interface for designers to create unique and varied battles. Designers can create a battle scenario with a tool, saving it to some format; developers read in this format and pass it to the `ArenaBuilder`. This can greatly assist in iterating quickly, without having to recode various components.

### Turn Management
**DISCLAIMER:** This section is still a work in progress. Looking at the example code and the source code itself is probably the best way to understand what's going on here.

### Interactions
**DISCLAIMER:** This section is still a work in progress. Looking at the example code and the source code itself is probably the best way to understand what's going on here.

Commands typically wrap actions. Commands are separate from Actions because
Actions are designed to be executed regardless of phase. You can think of
Commands as the actions that a player takes and Actions as the result of a
Command or another action (through the reaction type).
