using System.Collections.Generic;

namespace Spite
{
    /// <summary>
    /// Represents a team of entities in a battle.
    /// 
    /// This shouldn't be used - use the generic ITeam instead.
    /// </summary>
    public interface ITeam
    {
        /// <summary>
        /// The current standing of the team.
        /// </summary>
        TeamStanding CurrentStanding { get; }
        
        /// <summary>
        /// Determines and sets the current standing othe team in the arena.
        /// </summary>
        /// <param name="context">The arena this team is fighting in.</param>
        /// <returns>True if this team has achieved victory.</returns>
        TeamStanding DetermineStanding(IArena context);

        /// <summary>
        /// Forces the standing on the team.
        /// </summary>
        /// <param name="standing">The standing to give to the team.</param>
        void ForceStanding(TeamStanding standing);
    }

    /// <summary>
    /// A generic version of the team that allows for direct access to specific entity types.
    /// </summary>
    /// <typeparam name="T">The entity type this team revolves around.</typeparam>
    public interface ITeam<T> : ITeam where T : ITeamMate
    {
        /// <summary>
        /// The entities managed by this team.
        /// </summary>
        ICollection<T> Entities { get; }

        /// <summary>
        /// Adds an entity to the team.
        /// </summary>
        /// <param name="entity">The entity being added.</param>
        void AddEntity(T entity);

        /// <summary>
        /// The number of entities managed by this Team.
        /// </summary>
        int ManagedEntityCount { get; }

        /// <summary>
        /// Sets the number of entities slots on this team.
        /// </summary>
        /// <param name="entityCount">The number of entity slots to initialize.</param>
        void InitializeEntityCount(uint entityCount);
    }
}
