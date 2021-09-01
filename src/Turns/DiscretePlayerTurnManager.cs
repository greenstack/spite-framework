using Spite.Interaction;
using System.Collections.Generic;

namespace Spite.Turns
{
	/// <summary>
	/// An internal-use only interface for player objects.
	/// 
	/// I have this marked as internal because I don't want devs to believe that
	/// a player needs to implement this interface, since even though the player
	/// issues the commands, the player is rarely the executor of those commands
	/// (like in Pokemon, Fire Emblem, Final Fantasy, Earthbound, etc.)
	/// </summary>
	internal interface IPlayer : ITeam, ICommandExecutor { }

	/// <summary>
	/// Represents a turn manager that allows players to make decisions for as long
	/// as that player has priority.
	/// 
	/// In these cases, a player should be a team. (Allied players should be marked
	/// as such in an AllianceGraph.)
	/// </summary>
	public class DiscretePlayerTurnManager<TPlayer> : TeamTurnManagerBase<TPlayer>
		where TPlayer : ITeam, ICommandExecutor
	{
		/// <inheritdoc/>
		public DiscretePlayerTurnManager(IList<TPlayer> players, bool executeFollowUpsIfActionFailed = true) :
			base(players, new PlayerPhase<TPlayer>(GetFirstTeam(players)), executeFollowUpsIfActionFailed)
		{
		}

		/// <inheritdoc/>
		protected override ITurnPhase GetNextPhase()
		{
			return new PlayerPhase<TPlayer>(AdvanceToNextTeam());
		}
	}
}