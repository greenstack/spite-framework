using Spite.Interaction;
using System;

namespace Battleship
{
	class EnemyBattleshipTeam : BattleshipTeam
	{
		int index = 0;

		public override CommandBase GetCommand()
		{
			var command = new GuessCommand(this, Opponent, index % BattleshipBoard.BOARD_SIZE, index / BattleshipBoard.BOARD_SIZE);
			index++;
			return command;
		}

		public override string ToString()
		{
			return "Enemy";
		}
	}
}
