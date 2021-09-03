using Spite.Interaction;
using System.Collections.Generic;

namespace Spite.Turns
{
	/// <summary>
	/// TODO
	/// </summary>
	public interface ITeamExecutor : ITeam, ICommandExecutor { }

	/// <summary>
	/// TODO
	/// </summary>
	/// <typeparam name="TTeammate">The type of teammate held in the team.</typeparam>
	public interface ITeamExecutor<TTeammate> : ITeamExecutor, ITeam<TTeammate> where TTeammate : ITeammate { }

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
		protected override ITurnPhase CreatePhaseForNextTeam()
		{
			// Check if victory has occurred - probably through some kind of predicate
			return new PlayerPhase<TPlayer>(AdvanceToNextTeam());
		}
	}
}