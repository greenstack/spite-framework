using Spite;
using Spite.Actions;

namespace SpiteBattleship
{
    class GuessAction : ITeamAction<BattleshipTeam>
    {
        public BattleshipTeam Target { get; }

        public IArena Context { get; }

        /// <summary>
        /// If I recall correctly, C# 8 will allow more specific return types
        /// from interface implementations. When C# 8 is more widely available,
        /// it would be good to implement this.
        /// </summary>
        public IActionResult Result { get; private set; }

        public readonly int x, y;

        public GuessAction(BattleshipTeam target, IArena context, int x, int y)
        {
            Target = target;
            Context = context;
            this.x = x;
            this.y = y;
        }

        public IActionResult Execute()
        {
            Result = new GuessActionResult(Target.ReceiveGuess(x, y), x, y);
            return Result;
        }

        public void Accept(ITeamActionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
