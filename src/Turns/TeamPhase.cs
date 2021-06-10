using Spite.Interaction;
using System;
using System.Linq;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a phase in a turn that belongs to a team.
	/// </summary>
	public class TeamPhase : ITurnPhase
	{
		/// <summary>
		/// The team that can act this phase.
		/// </summary>
		public ITeamOfTappables CurrentTeam { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentTeam">The team that can act.</param>
		public TeamPhase(ITeamOfTappables currentTeam)
		{
			CurrentTeam = currentTeam;
		}

		/// <inheritdoc/>
		public ITurnPhase GetNextPhase()
		{
			// This actually won't do anything because it's not supposed to.
			// Discrete team turn managers get the next phase themselves.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Checks if the command can be executed.
		/// </summary>
		/// <param name="command">The command to execute.</param>
		/// <returns>True if the command can be executed this phase.</returns>
		public virtual bool IsCommandExecutableThisPhase(CommandBase command)
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));
			return command.Executor.ResponsibleTeam == CurrentTeam &&
				(command.Executor as ITappableTeammate)?.IsTapped != true;
		}

		/// <summary>
		/// Checks if the phase should advance.
		/// </summary>
		/// <param name="results">The results of the action. Ignored in this case.</param>
		/// <returns>True if each unit on the team has been tapped. Otherwise, false.</returns>
		public virtual bool ShouldAdvancePhase(IReaction[] results = null)
		{
			return CurrentTeam.TappedUnitCount >= CurrentTeam.ManagedEntityCount;
		}
	}
}
