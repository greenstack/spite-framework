namespace Spite
{
    /// <summary>
    /// Helps an Arena evaluate the order that turns are taken in.
    /// </summary>
    public enum TurnScheme
    {
        /// <summary>
        /// Turns are assigned to teams.
        /// 
        /// Examples: Fire Emblem, Battleship
        /// </summary>
        Team = 0x0,
        /// <summary>
        /// Turns are assigned to entities one-by-one.
        /// 
        /// Examples: Octopath Traveler, any game where entities act, sorted by
        /// something like an entity's speed.
        /// </summary>
        Entity = 0x1,
        /// <summary>
        /// Sides decide what each entity on their team will do at the same time.
        /// 
        /// Examples: Pokemon, Rock Paper Scissors/Roshambo
        /// </summary>
        VonNeumannTeam = 0x2,
        /// <summary>
        /// Sides decide what one entity will do at the same time.
        /// 
        /// Examples: I dunno
        /// </summary>
        VonNeumannEntity = 0x3
    }
}
