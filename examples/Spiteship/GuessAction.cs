using Spite;
using Spite.Actions;

namespace SpiteBattleship
{
    class GuessAction : BattleshipAction, ITeamAction<BattleshipTeam>
    {
        public BattleshipTeam Target { get; }
        public BattleshipTeam Actor { get; }

        public readonly int x, y;

        public GuessAction(BattleshipTeam actor, BattleshipTeam target, IArena context, int x, int y) : base(context)
        {
            Actor = actor;
            Target = target;
            this.x = x;
            this.y = y;
        }

        public override IActionResult Execute()
        {
            var result = new GuessActionResult(Target.ReceiveGuess(x, y), x, y);
            Actor.InformGuessStatus(result);
            Result = result;
            return Result;
        }

        public void Accept(ITeamActionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
