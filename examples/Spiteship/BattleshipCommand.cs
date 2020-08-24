using Spite;

namespace SpiteBattleship
{
    /// <summary>
    /// Provides a basic starter class for Battleship commands that act on a BattleshipTurnManager.
    /// </summary>
    abstract class BattleshipCommand : Command<BattleshipTurnManager>
    {
        public BattleshipCommand(BattleshipTurnManager context, IActor<BattleshipTeam> owner) : base(owner, context)
        {
        }
    }
}
