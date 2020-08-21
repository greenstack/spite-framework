using Spite;

namespace SpiteBattleship
{
    /// <summary>
    /// Causes the player to forfeit the game immediately.
    /// </summary>
    class ForfeitCommand : BattleshipCommand
    {
        public ForfeitCommand(IActor<BattleshipTeam> owner) : base(owner)
        {
        }

        /// <summary>
        /// No need to update the Team Standings because we're forcing a team standing.
        /// </summary>
        public override bool ShouldUpdateTeamStandings => false;

        public override bool Execute()
        {
            (Owner as IActor<BattleshipTeam>).Team.ForceStanding(TeamStanding.Eliminated);
            return true;
        }
    }
}
