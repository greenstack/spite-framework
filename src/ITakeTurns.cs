namespace Spite
{
    /// <summary>
    /// Represents an item that can have turns assigned to it.
    /// </summary>
    public interface ITakeTurns
    {
        /// <summary>
        /// Informs this item that its turn is beginning.
        /// </summary>
        /// <param name="context">The arena this item is participating in.</param>
        void BeginTurn(IArena context);

        /// <summary>
        /// Informs this object that its turn is ending.
        /// </summary>
        /// <param name="context">The arena this item is participating in.</param>
        void EndTurn(IArena context); 
    }
}
