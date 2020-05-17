namespace Spite
{
    /// <summary>
    /// Represents a team of entities in a battle.
    /// </summary>
    public interface ITeam
    {
        /// <summary>
        /// Are all entities managed by this Team still alive?
        /// </summary>
        bool AreAllAlive { get; }
        
        /// <summary>
        /// The number of living entities on this team.
        /// </summary>
        int AliveEntityCount { get; }
        
        /// <summary>
        /// The number of entities managed by this Team.
        /// </summary>
        int ManagedEntityCount { get; }
        
        /// <summary>
        /// Adds the entity onto the team.
        /// </summary>
        /// <param name="entity">The entity pertaining to the team.</param>
        void AddEntity(IEntity entity);

        /// <summary>
        /// Sets the number of entities slots on this team.
        /// </summary>
        /// <param name="entityCount">The number of entity slots to initialize.</param>
        void InitializeEntityCount(uint entityCount);

        /// <summary>
        /// The current standing of the team.
        /// </summary>
        TeamStanding CurrentStanding { get; }
        
        /// <summary>
        /// Determines and sets the current standing othe team in the arena.
        /// </summary>
        /// <param name="context">The arena this team is fighting in.</param>
        /// <returns>True if this team has achieved victory.</returns>
        TeamStanding DetermineStanding(Arena context);
    }
}
