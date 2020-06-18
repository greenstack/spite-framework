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
