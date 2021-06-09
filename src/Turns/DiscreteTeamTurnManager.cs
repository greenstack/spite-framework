using Spite.Interaction;
using System.Collections.Generic;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a turn manager that allows units on a team to act as long as that team
	/// is active.
	/// </summary>
	public class DiscreteTeamTurnManager :
		TurnManagerBase
	{
		/// <summary>
		/// The current team node.
		/// </summary>
		LinkedListNode<ITeam<ITappableTeammate>> currentTeamNode;

		readonly LinkedList<ITeam<ITappableTeammate>> teamsList;

		/// <summary>
		/// Gets the team with the current priority.
		/// </summary>
		public ITeam<ITappableTeammate> CurrentTeam => currentTeamNode.Value;

		/// <summary>
		/// Creates a discrete team turn manager.
		/// </summary>
		/// <param name="teams">The teams that can participate in this battle. Priority will be given in the order given by this list.</param>
		/// <param name="executeFollowUpsIfActionFailed">If a reaction has a follow-up, should it be executed even if the action failed? (Defaults to true)</param>
		public DiscreteTeamTurnManager(IList<ITeam<ITappableTeammate>> teams, bool executeFollowUpsIfActionFailed = true) :
			base(new TeamPhase(GetFirstTeam(teams)), executeFollowUpsIfActionFailed)
		{
			teamsList = new LinkedList<ITeam<ITappableTeammate>>(teams);
			currentTeamNode = teamsList.First;
		}

		private static ITeam<ITappableTeammate> GetFirstTeam(IList<ITeam<ITappableTeammate>> teams)
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
}
