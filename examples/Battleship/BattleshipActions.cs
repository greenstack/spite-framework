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

		public BattleshipTeam attacker;

		private readonly int xCoord;

		private readonly int yCoord;

		public AttackAction(BattleshipTeam attacker, BattleshipBoard board, int x, int y)
		{
			this.attacker = attacker;
			this.board = board;
			xCoord = x;
			yCoord = y;
		}

		public bool IsValid()
		{
			return BattleshipBoard.IsOnBoard(xCoord, yCoord) && !board.IsLocationHit(xCoord, yCoord);
		}

		public IReaction UseAndGetReaction()
		{
			Ship hitEnemy = board.Attack(xCoord, yCoord);
			return new AttackReaction(attacker, hitEnemy);
		}
	}
}
