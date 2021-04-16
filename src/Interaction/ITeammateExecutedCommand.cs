namespace Spite.Interaction
{
	/// <summary>
	/// Provides an interface for commands that are executed by teammates.
	/// </summary>
	public interface ITeammateExecutedCommand : ISpiteCommand
	{
		/// <summary>
		/// The teammate performing the action.
		/// </summary>
		ITeammate Executor { get; }
	}
}
