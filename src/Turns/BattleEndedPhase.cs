using Spite.Interaction;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a battle that has ended. This is the canonical "end of
	/// battle" phase, but it can be extended to suit your needs.
	/// </summary>
	public class BattleEndedPhase : ITurnPhase
	{
		/// <summary>
		/// Gets the next phase.
		/// </summary>
		/// <returns>This phase, since this is the last phase and there is no next phase.</returns>
		public ITurnPhase GetNextPhase() => this;

		/// <summary>
		/// Is the command executable this phase? In this case, the ansewr is always no.
		/// </summary>
		/// <param name="command">The command that might be executable.</param>
		/// <returns>False, since the Battle Ended Phase is the canonical end phase.</returns>
		public bool IsCommandExecutableThisPhase(CommandBase command) => false;

		/// <summary>
		/// Asks if the next phase should be obtained.
		/// </summary>
		/// <param name="results">The results of the most recent command.</param>
		/// <returns>False, since there is no next phase.</returns>
		public bool ShouldAdvancePhase(IReaction[] results) => false;
	}
}
