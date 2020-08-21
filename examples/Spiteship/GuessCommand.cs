using Spite;

namespace SpiteBattleship
{
    class GuessCommand : BattleshipCommand
    {
        private readonly int xCoord;
        private readonly int yCoord;
        private readonly BattleshipTeam Target;

        public GuessCommand(IActor<BattleshipTeam> owner, BattleshipTeam target, int x, int y) : base(owner)
        {
            xCoord = x;
            yCoord = y;
            Target = target;
        }

        public override bool ShouldUpdateTeamStandings => true;

        public override bool Execute()
        {
            bool hit = Target.ReceiveGuess(xCoord, yCoord);
            (Owner as IActor<BattleshipTeam>).Team.InformOfGuessAt(xCoord, yCoord, hit);
            return hit;
        }
    }
}
