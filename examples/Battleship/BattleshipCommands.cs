using Spite;
using Spite.Interaction;

namespace Battleship
{
    class ForfeitCommand : CommandBase
    {
        public ITeam ForfeitingTeam { get; }

        public ForfeitCommand(ITeam forfeitingTeam)
            : base(new ForfeitAction(forfeitingTeam), forfeitingTeam)
        {
            ForfeitingTeam = forfeitingTeam;
        }
    }

    class GuessCommand : CommandBase
	{
        public GuessCommand(BattleshipTeam attackingTeam, BattleshipTeam defendingTeam)
            : base(null, attackingTeam)
        { }
	}
}
