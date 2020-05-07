using Spite.Events;

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
        /// An event that is fired when Tap and Untap are called successfully.
        /// </summary>
        event TapStateChange OnTapOrUntap;

        /// <summary>
        /// If this entity is still alive.
        /// </summary>
        bool IsAlive { get; }
    }

    /// <summary>
    /// A delegate to call when an entity is tapped or untapped.
    /// </summary>
    /// <param name="sender">The entity whose state was changed.</param>
    /// <param name="args">Contextual information about the state change.</param>
    public delegate void TapStateChange(IEntity sender, EntityTapStateChangeEventArgs args);
}
