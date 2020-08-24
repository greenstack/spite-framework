using Spite;

namespace SpiteBattleship
{
    class GuessCommand : BattleshipCommand
    {
        private readonly int xCoord;
        private readonly int yCoord;
        private readonly BattleshipTeam Target;

        public GuessCommand(BattleshipTurnManager context, IActor<BattleshipTeam> owner, BattleshipTeam target, int x, int y) : base(context, owner)
        {
            xCoord = x;
            yCoord = y;
            Target = target;
        }

        public override bool ShouldUpdateTeamStandings => true;

        public override bool Execute()
        {
            return Context.SendPlayerAttack((Owner as BattleshipActor).Team, Target, xCoord, yCoord);
        }
    }
}
