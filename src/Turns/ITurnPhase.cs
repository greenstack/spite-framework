using Spite.Interaction;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a phase in a turn. These should be managed by the turn
	/// manager, and act as the manager's state.
	/// </summary>
	public interface ITurnPhase
	{
		/// <summary>
		/// Retrieves the next phase.
		/// </summary>
		/// <returns>The next phase.</returns>
		ITurnPhase GetNextPhase();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="results">The results of the applied command.</param>
		/// <returns>True if the phase should be advanced. See also <seealso cref="GetNextPhase"/></returns>
		bool ShouldAdvancePhase(IReaction[] results);

		/// <summary>
		/// Can the command be executed during this phase?
		/// </summary>
		/// <param name="command">The command that wants to be executed.</param>
		/// <returns>True if the command is allowed to be executed.</returns>
		bool IsCommandExecutableThisPhase(CommandBase command);
	}

	/// <summary>
	/// A delegate to be called when a turn's phase changes.
	/// </summary>
	/// <param name="fromPhase">The phase being transitioned from.</param>
	/// <param name="toPhase">The phase being transitioned to.</param>
	/// <param name="turnManager">The turn manager.</param>
	public delegate void ChangePhase(ITurnPhase fromPhase, ITurnPhase toPhase, ITurnManager turnManager);
}
