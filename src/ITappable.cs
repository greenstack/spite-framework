namespace Spite
{
    /// <summary>
    /// Represents an object that can be tapped. Used in the Arena's turn management system.
    /// </summary>
    public interface ITappable
    {
        /// <summary>
        /// Whether or not this object can act.
        /// </summary>
        bool Tapped { get; }

        /// <summary>
        /// Fired when the object is untapped.
        /// </summary>
        event Untap OnUntap;

        /// <summary>
        /// Fired when the object is tapped.
        /// </summary>
        event Tap OnTapped;
    }

    /// <summary>
    /// Represents when the Tappable is untapped.
    /// </summary>
    public delegate void Untap();

    public delegate void Tap();
}
