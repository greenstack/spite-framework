using Spite;
using System;

namespace SpiteBattleship
{
    class GuessCommand : BattleshipCommand
    {
        private readonly int xCoord;
        private readonly int yCoord;
        private readonly BattleshipTeam Target;

        public GuessCommand(IActor owner, BattleshipTeam target, int x, int y) : base(owner)
        {
            xCoord = x;
            yCoord = y;
            Target = target;
        }

        public override bool Execute()
        {
            return Target.ReceiveGuess(xCoord, yCoord);
        }
    }
}
