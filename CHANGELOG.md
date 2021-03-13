# Alpha 0.2.0 (Work in Progress)
## API Changes
### Arenas
 - Made methods for getting teams templated to move the onus of casting teams to a specific type to the API instead of the developer. A non-generic version is still available.

### Teams
- "Sides" don't exist as a concept anymore. They've been unified with teams (see #7 for further discussion)
- Added a generic version of `ITeam` - `ITeam<T> : ITeam where T : IEntity`. This should provide more flexibility. Any entity-related interface declarations has been migrated to the generic version.
- Changed `TeamBuilder` class declaration to `TeamBuilder<TTeam, TEntity> where TTeam : ITeam<TEntity> where TEntity : IEntity`. This addresses issue #2 and the addition of the generic `ITeam`.

### Entities -> TeamMates
- Renamed Entities to Team Mates.
  - `ITeamMate` is now the interface name.
- Removed `bool IEntity.IsAlive`. Use `ITeamMate.Status` instead.
- Introduced the `ITeamMate.Status` enum.
  - There are {n} values:
    - `Dead`: Team Mate has been defeated in battle.
    - `Inactive`: Team Mate isn't actively participating in battle.
    - `Alive`: Team Mate is alive. 
    - `Active`: Team Mate isn't actively participating in battle.


### Removals
- Removed `ITappable` and `ITappableEntity`. They didn't seem too useful.

## Other Changes
- Updated assembly name to "Spite Framework". Default namespace is still Spite.

# Alpha 0.1.0
- Initial release for the Spite Framework
