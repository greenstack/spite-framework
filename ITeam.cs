﻿using System.Linq.Expressions;

namespace Spite
{
    /// <summary>
    /// Represents a team of entities in a battle.
    /// </summary>
    public interface ITeam
    {
        /// <summary>
        /// If all entities have been tapped.
        /// </summary>
        bool AreAllEntitiesTapped { get; }
        
        /// <summary>
        /// The number of untapped entities on this team.
        /// </summary>
        int UntappedEntityCount { get; }
        
        /// <summary>
        /// Untaps all entities managed by this team.
        /// </summary>
        void UntapAll();
        
        /// <summary>
        /// Untaps the specific entity on this team.
        /// </summary>
        /// <param name="entity">The entity to untap.</param>
        void Untap(IEntity entity);
        
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
        /// <param name="isSizeCapped">Whether or not entityCount should be the max number of entities on this team.</param>
        void InitializeEntityCount(uint entityCount, bool isSizeCapped);

        /// <summary>
        /// The current standing of the team.
        /// </summary>
        TeamStanding CurrentStanding { get; }
        
        /// <summary>
        /// Checks if this team has won.
        /// </summary>
        /// <param name="context">The arena this team is fighting in.</param>
        /// <returns>True if this team has achieved victory.</returns>
        TeamStanding DetermineStanding(Arena context);
    }
}
