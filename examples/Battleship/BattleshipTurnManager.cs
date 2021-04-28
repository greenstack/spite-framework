using Spite.Turns;

namespace Battleship
{
	class BattleshipTurnManager : TurnManagerBase
	{
		public BattleshipTurnManager(PlayerBattleshipTeam playerTeam, EnemyBattleshipTeam enemyTeam) 
			: base(new PlayerPhase(playerTeam, enemyTeam), false)
		{
		}
	}
}
