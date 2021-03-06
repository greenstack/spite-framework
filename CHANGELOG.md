# 0.3.0-alpha
## Unity Integration
(See Issue #12)

Spite can now be added to the `Packages` folder of a Unity project and used
by Unity scripts. See the project's `README.md` for more info on how to install
Spite in Unity.

## Discrete Team Turn Manager (DTTM)
(See Issue #20)

Spite now supports Discrete Team Turn Managers. By default, this turn manager
will allow a player to perform actions until each unit is tapped. The Arena
Builder has been modified to allow developers to choose this method without
having to configure the DTTM themselves - it will build it for you. This is done
through the Arena Builder's `SetTurnScheme` method passing `DiscreteTeam` as the
value.

## General Changes
 - Re-introduced the `ITappableTeammate` interface.
 - Added `ITeamOfTappables` interface. Extends `ITeam`. A generic version of the interface is also available and requires the team's entity to implement `ITappableTeammate`.
 - Added `TeamPhase` turn phase class.
 - Added `ICommandExecutor`.
 - Changed `ISpiteCommand.Executor` type from `object` to `ICommandExecutor`.
 - Added protected virtual method `TurnManagerBase.GetNextPhase` to let concrete Turn Managers (such as the DTTM) determine what the next phase for that.
 - Fixed the default namespace for unit tests (was `spite-framework`, is now `Spite.UnitTests`).
 - Added a command, action, and reaction to allow all teammates`ITappableTeammateTeams` to be tapped through a single command.
 - Moved `ManagedEntityCount` from `ITeam<T>` to `ITeam`.
 - Moved `InitializeEntityCount` from `ITeam<T>` to `ITeam.`
 - Added compatibility with .NET Framework 4.5+.

# Alpha 0.2.1
This update only changes the Spite.csproj file to allow NuGet to properly link to the repository.

Because these changes are only related to publishing on NuGet, using the 0.2.0-alpha branch or tag
is functionally equivalent.

# Alpha 0.2.0
## Major Additions and Changes
### Alliance Graphs
Alliance Graphs are data structures that are designed to simplify tracking
relationships between teams. These relationships are directed, meaning that
even though `TeamA` has the `Opposing` relationship with `TeamB`, it doesn't
necessarily mean that `TeamB` has the `Opposing` relationship with `TeamA`.
The `AllianceGraph` class implements the new `IAllianceTracker` interface,
which allows for other implementations. Using those implementations with the
Arena Builder and default Arena class are not currently supported.

### The Command-Action-Reaction (CAR) Model
The Command-Action-Reaction (CAR) model is now the main method for interacting
with the Spite Framework.

## API Changes
### Arenas
- Made methods for getting teams templated to move the onus of casting teams to a specific type to the API instead of the developer. A non-generic version is still available.
- Removed the `ReceiveAndExecuteCommand<TContext>` method. It has been replaced with `Spite.Interaction.IReaction[] ReceiveAndExecuteCommand(Spite.Interaction.CommandBase)` method.
- Made the `StartBattle` method obsolte. The CAR model should work better and be able to accomplish the same thing.

### Entities -> Teammates
- Renamed Entities to Teammates.
  - `ITeammate` is now the interface name.
- Removed `bool IEntity.IsAlive`. Use `ITeammate.Status` instead.
- Introduced the `TeammateStatus` enum.
  - There are 4 values:
    - `Dead`: Team Mate has been defeated in battle.
    - `Inactive`: Team Mate isn't actively participating in battle.
    - `Alive`: Team Mate is alive. 
    - `Active`: Team Mate isn't actively participating in battle.

### Teams
- "Sides" don't exist as a concept anymore. They've been unified with teams (see #7 for further discussion)
- Added a generic version of `ITeam` - `ITeam<T> : ITeam where T : ITeammate`. This should provide more flexibility. Any entity-related interface declarations has been migrated to the generic version.
- Changed `TeamBuilder` class declaration to `TeamBuilder<TTeam, TEntity> where TTeam : ITeam<TEntity> where TEntity : IEntity`. This addresses issue #2 and the addition of the generic `ITeam`.
- Changed `ITeam.Entities` to `ITeam.Members`.

### `Turns` Namespace
`TurnScheme`, `ITurnPhase`, and `ITurnManager` have all been moved to the `Spite.Turns` namespace.

### TurnManager
- Removed the `CanBeExecuted<TConext>` method. The `AcceptCommand` can accomplish
the same thing.
- Removed the `CanAct(IActor)` method.

### `enum TurnScheme` -> `enum TurnSchemeTypes`
- Renamed the enum to TurnSchemeTypes.
- Renamed each of the enum values.
  - `Team` -> `DiscreteTeam`
  - `Entity` -> `DiscreteTeammate`
  - `VonNeumannTeam` -> `SimultaneousTeam`
  - `VonNeumannEntity` -> `SimultaneousTeammate`
  - Adding the word `Discrete` helps clarify what those enum values should mean.
    Also, by changing `VonNeumann` to `Simultaneous`, I believe that the new name
    is easier to understand. Finally, changing `Entity` to `Teammate` reflects
    the other changes made across the framework.

### Removals
- Removed `ITappable` and `ITappableEntity`. They didn't seem too useful.
- Removed `Spite.Queries.TeamQueries`. All the queries relied on other removed 
  features.
- Removed the `Spite.ICommand` interface and the classes implemented here. Those
  have been replaced by the commands in the `Spite.Interactions` namespace.

## Other Changes
- Updated assembly name to "Spite Framework". Default namespace is still Spite.

# Alpha 0.1.0
- Initial release for the Spite Framework
