using System;
using Spite;
using Spite.Interaction;
using Spite.Turns;

namespace Battleship
{
	/// <summary>
	/// The player's phase.
	/// </summary>
	class PlayerPhase : ITurnPhase
	{
		public BattleshipTeam PlayerTeam { get; }

		private readonly BattleshipTeam enemyTeam;

		public PlayerPhase(BattleshipTeam playerTeam, BattleshipTeam enemyTeam)
		{
			PlayerTeam = playerTeam;
			this.enemyTeam = enemyTeam;
		}

		public ITurnPhase GetNextPhase()
		{
			if (enemyTeam.CurrentStanding == TeamStanding.Defeated)
			{
				return new BattleEndedPhase();
			}
			else if (PlayerTeam.CurrentStanding == TeamStanding.Defeated)
			{
				// TODO: Distinguish victors and losers
				return new BattleEndedPhase();
			}
			else
			{
				return new EnemyPhase(enemyTeam, PlayerTeam);
			}
		}

		public bool IsCommandExecutableThisPhase(CommandBase command)
		{
			return command.Executor.Equals(PlayerTeam);
		}

		public bool ShouldAdvancePhase(IReaction[] results)
		{
			return results[0].ActionSuccessful;
		}
	}

	class EnemyPhase : ITurnPhase
	{
		public BattleshipTeam EnemyTeam { get; }

		private readonly BattleshipTeam playerTeam;

		public EnemyPhase(BattleshipTeam enemyTeam, BattleshipTeam playerTeam)
		{
			EnemyTeam = enemyTeam;
			this.playerTeam = playerTeam;
		}

		public ITurnPhase GetNextPhase()
		{
			if (playerTeam.CurrentStanding == TeamStanding.Defeated)
			{
				return new BattleEndedPhase();
			}
			else
			{
				return new PlayerPhase(playerTeam, EnemyTeam);
			}
		}

		public bool IsCommandExecutableThisPhase(CommandBase command)
		{
			return command.Executor.Equals(EnemyTeam);
		}

		public bool ShouldAdvancePhase(IReaction[] results)
		{
			return results[0].ActionSuccessful;
		}
	}
}
