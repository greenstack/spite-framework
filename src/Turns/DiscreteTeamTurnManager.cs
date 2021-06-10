using System.Collections.Generic;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a turn manager that allows units on a team to act as long as that team
	/// is active.
	/// </summary>
	/// <typeparam name="T">The type of team that is used. Must use tappable teammates.</typeparam>
	public class DiscreteTeamTurnManager<T> : TurnManagerBase
		where T : ITappableTeammateTeam
	{
		/// <summary>
		/// The current team node.
		/// </summary>
		LinkedListNode<T> currentTeamNode;

		readonly LinkedList<T> teamsList;

		/// <summary>
		/// Gets the team with the current priority.
		/// </summary>
		public T CurrentTeam => currentTeamNode.Value;

		/// <summary>
		/// Creates a discrete team turn manager.
		/// TODO: Look into a parameter for "auto advance to next phase when all are tapped" or "go to next phase on command".
		/// This should probably be a public modifiable member to handle certain scenarios where skills can be used outside of the
		/// normal context.
		/// </summary>
		/// <param name="teams">The teams that can participate in this battle. Priority will be given in the order given by this list.</param>
		/// <param name="executeFollowUpsIfActionFailed">If a reaction has a follow-up, should it be executed even if the action failed? (Defaults to true)</param>
		public DiscreteTeamTurnManager(IList<T> teams, bool executeFollowUpsIfActionFailed = true) 
			: base(new TeamPhase(GetFirstTeam(teams)), executeFollowUpsIfActionFailed)
		{
			teamsList = new LinkedList<T>(teams);
			currentTeamNode = teamsList.First;
		}

		private static T GetFirstTeam(IList<T> teams)
		{
			if (teams is null || teams.Count == 0)
			{
				throw new System.ArgumentNullException(nameof(teams), Properties.Resources.EmptyOrNullTeamListExceptionMessage);
			}
			return teams[0];
		}

		/// <summary>
		/// Retrieves the next phase.
		/// </summary>
		/// <returns>The phase with the next team.</returns>
		protected override ITurnPhase GetNextPhase()
		{
			// Go to the next team or cycle back
			currentTeamNode = currentTeamNode.Next ?? teamsList.First;
			return new TeamPhase(CurrentTeam);
		}
	}

	/// <summary>
	/// A discrete team turn manager that defaults to ITappableTeammateTeam as the team type.
	/// </summary>
	public class DiscreteTeamTurnManager : DiscreteTeamTurnManager<ITappableTeammateTeam>
	{
		/// <summary>
		/// Creates a default discrete team turn manager.
		/// </summary>
		/// <param name="teams"></param>
		/// <param name="executeFollowUpsIfActionFailed"></param>
		public DiscreteTeamTurnManager(IList<ITappableTeammateTeam> teams, bool executeFollowUpsIfActionFailed = true) : base(teams, executeFollowUpsIfActionFailed)
		{
		}
	}
}
