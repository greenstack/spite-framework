# Alpha 0.2.0 (Work in Progress)
## API Changes
- Added a generic version of `ITeam` - `ITeam<T> : ITeam where T : IEntity`. This should provide more flexibility. Any entity-related interface declarations has been migrated to the generic version.
- Changed `TeamBuilder` class declaration to `TeamBuilder<TTeam, TEntity> where TTeam : ITeam<TEntity> where TEntity : IEntity`. This addresses issue #2 and the addition of the generic `ITeam`.
- "Sides" don't exist as a concept anymore. They've been unified with teams.
- Removed `ITappable` and `ITappableEntity`. They didn't seem too useful.

## Other Changes
- Updated assembly name to "Spite Framework". Default namespace is still Spite

# Alpha 0.1.0
- Initial release for the Spite Framework
