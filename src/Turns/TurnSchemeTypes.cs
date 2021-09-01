namespace Spite.Turns
{
    /// <summary>
    /// Helps an Arena evaluate the order that turns are taken in.
    /// </summary>
    public enum TurnSchemeType
    {
        /// <summary>
        /// Turns are assigned to teams.
        /// 
        /// Examples: Fire Emblem, Advance Wars.
        /// 
        /// For example, in Fire Emblem, a turn is given to a team until all units
        /// on that team have been tapped.
        /// </summary>
        DiscreteTeam,
        /// <summary>
        /// Turns are assigned to players (in Spite, they are also the team).
        /// 
        /// This default turn scheme should only be used when players can only
        /// do one thing per turn and there aren't really that many phases in a
        /// player's turn. For example, a game like Magic: The Gathering should
        /// use a custom turn manager rather than this one, due to the nature of
        /// the many phases, Magic's stack, and so forth.
        /// 
        /// Examples: Battleship, Chess.
        /// </summary>
        DiscretePlayer,
        /// <summary>
        /// Turns are assigned to entities one-by-one.
        /// 
        /// Examples: Octopath Traveler, any game where entities act, sorted by
        /// something like an entity's speed.
        /// </summary>
        DiscreteTeammate,
        /// <summary>
        /// Sides decide what each entity on their team will do at the same time.
        /// 
        /// Examples: Pokemon.
        /// </summary>
        SimultaneousTeam,
        /// <summary>
        /// Sides decide what one entity will do at the same time.
        /// 
        /// Examples: I dunno
        /// </summary>
        SimultaneousTeammate,
        /// <summary>
        /// Players decide what they will do simultaneously.
        /// 
        /// Examples: Rock Paper Sciessors/Roshambo.
        /// </summary>
        SimultaneousPlayer,
    }
}
