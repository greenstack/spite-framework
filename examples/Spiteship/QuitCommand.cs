using Spite;
using Spite.Actions;
using System;

namespace SpiteBattleship
{
    /// <summary>
    /// Causes the performer to lose the game via withdrawal/forfeit.
    /// </summary>
    class QuitCommand : BattleshipAction
    {
        readonly ITeam performer;

        public QuitCommand(IArena context, ITeam performer) : base(context)
        {
            this.performer = performer;
        }

        public override IActionResult Execute()
        {
            performer.ForceStanding(TeamStanding.Eliminated);
            return null;
        }
    }
}
