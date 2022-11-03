# 0.5.0-alpha
## Language/Framework Updates
 - Removed support for .NET Framework 4.5
 - Set target framework to .NET 6.0
 - Set language version to 9.0 (Note that Unity [doesn't support all C# 9](https://docs.unity3d.com/2022.2/Documentation/Manual/CSharpCompiler.html)
 features still.) [Godot 4.0](https://godotengine.org/article/dev-snapshot-godot-4-0-beta-1)
 will support language features for C# 10 and supports all language features.

## API Changes
 - Removed all functionality except for Stats.
   - See [this discussion](https://github.com/greenstack/spite-framework) for more details.

# 0.4.0-alpha
## Language Updates
With Unity 2021.2, Unity supports [all features of C# 8 and many C# 9 features.](https://docs.unity3d.com/2021.2/Documentation/Manual/CSharpCompiler.html) While we don't necessarily need all these C# 9.0 features that aren't
supported, limiting the project to C# 8.0 features is the most surefire way to maintain Unity support.

## API Changes
### `IReaction`
- Reactions now contain a refernce to the action that created it.

### `ITeam`
- Changed the `Members` type from `ICollection` to `ITeam`. This will make
accessing individual teammates by a known index or iterating over each teammate
to find an index much simpler by removing the reliance on Linq.

### `ITurnManager`
- [Issue #48](https://github.com/greenstack/spite-framework/issues/48) Turn 
managers now keep track of their turn numbers. The `TurnIncremented` event is
fired when that number is incremented. Concrete turn managers need to do
increment the `TurnNumber` field on their own.

### Rudimentary Stat Types
- Until Unity gets .NET 6 support, Spite provides some concrete int and float stats.

# 0.3.0-alpha
## Unity Integration
(See [Issue #12](https://github.com/greenstack/spite-framework/issues/12))

Spite can now be added to the `Packages` folder of a Unity project and used
by Unity scripts. See the project's `README.md` for more info on how to install
Spite in Unity.

The minimum supported version of Unity is 2019. See [Issue #29](https://github.com/greenstack/spite-framework/issues/29)
for more info.

## Turn Managers
This update introduces a lot of changes to the turn managers, providing some
default turn managers for the developer. More are on the way, but for now, these
are the turn managers that are available.

## ITurnManager
Added the `IsBattleOver` property. It holds a `Func<bool>` that devs can set at
Arena creation. It is used to determine if a battle has ended.

### Discrete Team Turn Manager (DTTM)
(See [Issue #20](https://github.com/greenstack/spite-framework/issues/20))

Spite now supports Discrete Team Turn Managers. By default, this turn manager
will allow a player to perform actions until each unit is tapped. The Arena
Builder has been modified to allow developers to choose this method without
having to configure the DTTM themselves - it will build it for you. This is done
through the Arena Builder's `SetTurnScheme` method passing `DiscreteTeam` as the
value.

### Discrete Player Turn Manager (DPTM)
(See [Issue #39](https://github.com/greenstack/spite-framework/issues/39))

In addition to the DTTM, Spite provides a Discrete Player Turn Manager. The
primary use case for this is games where players are the actors, not the
teammates, as in chess and battleship (usually because only one action can be
made in a turn and these teammates aren't really tappable in these scenarios).

This default turn manager can be used through the Arena Builder's `SetTurnScheme`
method passing in `DiscretePlayer` as the value.

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
 - Set target version of C# to 7.3 (See [Issue #29](https://github.com/greenstack/spite-framework/issues/29))
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
