namespace Spite
{
    /// <summary>
    /// Helps an Arena evaluate the order that turns are taken in.
    /// </summary>
    public enum TurnScheme
    {
        /// <summary>
        /// Turns are assigned to teams.
        /// </summary>
        Team = 0x0,
        /// <summary>
        /// Turns are assigned to entities one-by-one.
        /// </summary>
        Entity = 0x1,
        /// <summary>
        /// Sides decide what each entity on their team will do at the same time.
        /// </summary>
        VonNeumannTeam = 0x2,
        /// <summary>
        /// Sides decide what one entity will do at the same time.
        /// </summary>
        VonNeumannEntity = 0x3
    }
}
