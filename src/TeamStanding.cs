namespace Spite
{
    /// <summary>
    /// Enumerates the possible standings of a team in a battle.
    /// </summary>
    public enum TeamStanding
    {
        /// <summary>
        /// The team has been eliminated from the battle.
        /// </summary>
        Eliminated,
        /// <summary>
        /// The team has been defeated but is still in battle.
        /// </summary>
        Defeated,
        /// <summary>
        /// The team is not an active participant in the battle.
        /// </summary>
        Inactive,
        /// <summary>
        /// The team hasn't been defeated, eliminated, or gained victory.
        /// </summary>
        Competing,
        /// <summary>
        /// The team is considered victorious in the battle.
        /// </summary>
        Victorious,
    }
}
