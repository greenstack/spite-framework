using System.Collections.Generic;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a turn manager that allows units on a team to act as long as that team
	/// is active.
	/// </summary>
	/// <typeparam name="TTeam">The type of team that is used. Must use tappable teammates.</typeparam>
	public class DiscreteTeamTurnManager<TTeam> : TeamTurnManagerBase<TTeam>
		where TTeam : ITeamOfTappables
	{
		/// <summary>
		/// Creates a discrete team turn manager.
		/// TODO: Look into a parameter for "auto advance to next phase when all are tapped" or "go to next phase on command".
		/// This should probably be a public modifiable member to handle certain scenarios where skills can be used outside of the
		/// normal context.
		/// </summary>
		/// <param name="teams">The teams that can participate in this battle. Priority will be given in the order given by this list.</param>
		/// <param name="executeFollowUpsIfActionFailed">If a reaction has a follow-up, should it be executed even if the action failed? (Defaults to true)</param>
		public DiscreteTeamTurnManager(IList<TTeam> teams, bool executeFollowUpsIfActionFailed = true) 
			: base(teams, new TeamPhase(GetFirstTeam(teams)), executeFollowUpsIfActionFailed)
		{
		}

		/// <summary>
		/// Retrieves the next phase.
		/// </summary>
		/// <returns>The phase with the next team.</returns>
		protected override ITurnPhase CreatePhaseForNextTeam()
		{
			// Untap everyone to make sure that when priority comes back to them,
			// they can act. This clearly isn't optimal, but for now, this should
			// suffice.
			CurrentTeam.UntapAll();
			// Go to the next team or cycle back
			return new TeamPhase(AdvanceToNextTeam());
		}
	}

	/// <summary>
	/// A discrete team turn manager that defaults to ITappableTeammateTeam as the team type.
	/// </summary>
	public class DiscreteTeamTurnManager : DiscreteTeamTurnManager<ITeamOfTappables>
	{
		/// <summary>
		/// Creates a default discrete team turn manager.
		/// </summary>
		/// <param name="teams">The teams to be managed by the DTTM.</param>
		/// <param name="executeFollowUpsIfActionFailed">Should follow-up actions defined in reactions happen if the action failed?</param>
		public DiscreteTeamTurnManager(IList<ITeamOfTappables> teams, bool executeFollowUpsIfActionFailed = true) : base(teams, executeFollowUpsIfActionFailed)
		{
		}
	}
}
