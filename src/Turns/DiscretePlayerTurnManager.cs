using Spite.Interaction;
using System.Collections.Generic;

namespace Spite.Turns
{
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
			base(players, null, executeFollowUpsIfActionFailed)
		{
		}
	}
}