using System.Collections.Generic;

namespace Spite.Turns
{
	/// <summary>
	/// Provides common functionality for turn managers that manage teams.
	/// </summary>
	public abstract class TeamTurnManagerBase<TTeam> : TurnManagerBase
		where TTeam : ITeam
	{
		private LinkedListNode<TTeam> currentTeamNode;

		readonly LinkedList<TTeam> teamsList;

		/// <summary>
		/// Gets the team with the current priority.
		/// </summary>
		public TTeam CurrentTeam => currentTeamNode.Value;

		/// <summary>
		/// Constructs a team turn manager base object.
		/// </summary>
		/// <param name="teams">The teams that will be managed in this combat.</param>
		/// <param name="initialPhase">The starting phase of the battle.</param>
		/// <param name="executeFollowUpsIfActionFailed">If an action failed but there are still follow-up actions and this is set to true, those follow-up actions will be executed.</param>
		public TeamTurnManagerBase(IList<TTeam> teams, ITurnPhase initialPhase, bool executeFollowUpsIfActionFailed = true) :
			base(initialPhase, executeFollowUpsIfActionFailed)
		{
			teamsList = new LinkedList<TTeam>(teams);
			currentTeamNode = teamsList.First;
		}

		/// <inheritdoc/>
		protected sealed override ITurnPhase GetNextPhase()
		{
			if (IsBattleOver())
				return new BattleEndedPhase();
			return CreatePhaseForNextTeam();
		}

		/// <summary>
		/// Creates the phase for the next team.
		/// </summary>
		/// <returns>The phase for the next team.</returns>
		protected abstract ITurnPhase CreatePhaseForNextTeam();

		/// <summary>
		/// Gets the first team given in a list.
		/// </summary>
		/// <param name="teams">The list of teams managed by the turn manager.</param>
		/// <returns>The first team in the list.</returns>
		protected static TTeam GetFirstTeam(IList<TTeam> teams)
		{
			if (teams is null || teams.Count == 0)
			{
				throw new System.ArgumentNullException(nameof(teams),
#if !(UNITY_STANDALONE || UNITY_EDITOR)
					Properties.Resources.EmptyOrNullTeamListExceptionMessage
#else
					"Teams cannot be empty or null"
#endif
				);
			}
			return teams[0];
		}

		/// <summary>
		/// Advances to the next active team.
		/// </summary>
		/// <returns>The next active team in the list.</returns>
		protected TTeam AdvanceToNextTeam()
		{
			// There aren't any more teams, so don't bother advancing.
			if (teamsList.Count == 1)
				return CurrentTeam;
			// Players will need to verify whether or not the current team is acceptable.
			currentTeamNode =  currentTeamNode.Next ?? teamsList.First;
			return CurrentTeam;
		}
	}
}
