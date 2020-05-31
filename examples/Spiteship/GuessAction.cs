using Spite;
using Spite.Actions;

namespace SpiteBattleship
{
    class GuessAction : ITeamAction<BattleshipTeam>
    {
        public BattleshipTeam Target { get; }

        public IArena Context { get; }

        int x, y;

        public GuessAction(BattleshipTeam target, IArena context, int x, int y)
        {
            Target = target;
            Context = context;
            this.x = x;
            this.y = y;
        }

        public IActionResult Execute()
        {
            return new GuessActionResult(Target.ReceiveGuess(x, y));
        }
    }
}
