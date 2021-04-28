using System;
using Spite;
using Spite.Interaction;

namespace Battleship
{
	class ForfeitReaction : IReaction
	{
		private readonly ITeam forfeitedTeam;

		public ForfeitReaction(ITeam forfeitedTeam)
		{
			this.forfeitedTeam = forfeitedTeam;
		}

		public ISpiteAction FollowUpAction => null;

		public bool ActionSuccessful => true;

		public object GetReactionData()
		{
			return null;
		}

		public TReactionData GetReactionData<TReactionData>()
		{
			return default;
		}

		public override string ToString()
		{
			return $"{forfeitedTeam} forfeit!";
		}
	}

	class AttackReaction : IReaction
	{
		/// <summary>
		/// No kinds of counter-attacks here
		/// </summary>
		public ISpiteAction FollowUpAction => null;

		private Ship hitShip;

		private BattleshipTeam attacker;

		private bool enemyShipWasHit => hitShip != null;

		private bool shipSunk => hitShip?.Status == TeammateStatus.Defeated;

		public AttackReaction(BattleshipTeam attacker, Ship hitShip)
		{
			this.hitShip = hitShip;
		}

		public bool ActionSuccessful => true;

		public object GetReactionData()
		{
			throw new NotImplementedException();
		}

		public TReactionData GetReactionData<TReactionData>()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"{attacker} {(enemyShipWasHit ? "Hit!" : "Miss...")}{(shipSunk ? $" Sunk opponent's {hitShip.Name}" : "")}";
		}
	}
}
