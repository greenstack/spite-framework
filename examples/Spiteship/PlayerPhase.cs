using Spite;
using System.Linq;

namespace SpiteBattleship
{
    class PlayerPhase : BattleshipTurnPhase
    {
        public static PlayerBattleshipController player;

        public override BattleshipAction GetAction(IArena arena, BattleshipTurnManager turnManager)
        {
            int x = 0, y = 0;
            bool quit = player.askPlayerForInput(ref x, ref y);
            if (quit)
            {
                return new QuitCommand(arena, player.Team);
            }
            else
            {
                var opponent = arena.GetTeamsOpposing(player.ConcreteTeam).First();
                return new GuessAction(
                    player.Team as BattleshipTeam,
                    opponent as BattleshipTeam,
                    arena,
                    x,
                    y
                );
            }
        }
    }
}
