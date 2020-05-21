﻿using Spite.Events;

namespace Spite
{
    /// <summary>
    /// Represents an entity that the SpiteFramework can interact with.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The team this entity belongs to.
        /// </summary>
        ITeam Team { get; }

        /// <summary>
        /// If this entity is still alive.
        /// </summary>
        bool IsAlive { get; }
    }    
}