namespace Spite.Turns
{
    /// <summary>
    /// Helps an Arena evaluate the order that turns are taken in.
    /// </summary>
    public enum TurnSchemeTypes
    {
        /// <summary>
        /// Turns are assigned to teams.
        /// 
        /// Examples: Fire Emblem, Battleship.
        /// 
        /// For example, in Fire Emblem, a turn is given to a team until all units
        /// on that team have been tapped.
        /// </summary>
        DiscreteTeam = 0x0,
        /// <summary>
        /// Turns are assigned to entities one-by-one.
        /// 
        /// Examples: Octopath Traveler, any game where entities act, sorted by
        /// something like an entity's speed.
        /// </summary>
        DiscreteTeammate = 0x1,
        /// <summary>
        /// Sides decide what each entity on their team will do at the same time.
        /// 
        /// Examples: Pokemon, Rock Paper Scissors/Roshambo.
        /// </summary>
        SimultaneousTeam = 0x2,
        /// <summary>
        /// Sides decide what one entity will do at the same time.
        /// 
        /// Examples: I dunno
        /// </summary>
        SimultaneousTeammate = 0x3
    }
}
