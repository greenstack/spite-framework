namespace Spite
{
    /// <summary>
    /// Represents an entity that the SpiteFramework can interact with.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// If this entity is untapped.
        /// </summary>
        bool IsTapped { get; }

        /// <summary>
        /// The team this entity belongs to.
        /// </summary>
        ITeam Team { get; }
        
        /// <summary>
        /// Taps this entity.
        /// </summary>
        /// <returns>TRUE if the unit was successfully tapped.</returns>
        bool Tap();

        /// <summary>
        /// Untaps this entity.
        /// </summary>
        /// <returns>TRUE if the unit was successfully untapped.</returns>
        bool Untap();

        /// <summary>
        /// If this entity is still alive.
        /// </summary>
        bool IsAlive { get; }
    }
}
