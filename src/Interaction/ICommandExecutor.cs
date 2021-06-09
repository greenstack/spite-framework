namespace Spite.Interaction
{
	/// <summary>
	/// Provides an interface for objects that can execute commands.
	/// </summary>
	public interface ICommandExecutor
	{
		/// <summary>
		/// The team responsible for this executor.
		/// </summary>
		ITeam ResponsibleTeam { get; }
	}
}
