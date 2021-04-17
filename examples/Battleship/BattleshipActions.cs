using System;
using Spite;
using Spite.Interaction;

namespace Battleship
{
	class ForfeitAction : ISpiteAction
	{
		readonly ITeam team;

		public ForfeitAction(ITeam team)
		{
			// It's generally a good idea to program as generically as possible
			// In fact, this is so generic, I think I might be able to port this
			// over to the main code itself. I guess it depends on how the reaction
			// is developed.
			this.team = team;
		}

		public ITeammate User => null;

		public bool IsValid() => true;

		public IReaction UseAndGetReaction()
		{
			team.ForceStanding(TeamStanding.Defeated);
			// Need to get this to return a proper reaction
			return new ForfeitReaction(team);
		}
	}

	class AttackAction : ISpiteAction
	{
		public ITeammate User => null;

		public readonly BattleshipBoard board;

		private readonly int xCoord;

		private readonly int yCoord;

		public AttackAction(BattleshipBoard board, int x, int y)
		{
			this.board = board;
			xCoord = x;
			yCoord = y;
		}

		public bool IsValid()
		{
			return BattleshipBoard.IsOnBoard(xCoord, yCoord);
		}

		public IReaction UseAndGetReaction()
		{
			throw new NotImplementedException();
		}
	}
}
