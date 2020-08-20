namespace Spite
{
    /// <summary>
    /// Represents an actor that can act on the battle in some way.
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// This actor's name.
        /// </summary>
        string Name { get; }
    }
}
