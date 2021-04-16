namespace Spite.Interaction
{
	/// <summary>
	/// Represents a basic command being executed by a team.
	/// </summary>
	public abstract class TeamExecutedCommandBase : CommandBase, ITeamExecutedCommand
	{
		/// <inheritdoc/>
		public ITeam Executor { get; }

		/// <summary>
		/// Builds a basic command executed at the team level.
		/// </summary>
		/// <param name="user">The team executing the command.</param>
		/// <param name="action">The action being executed.</param>
		public TeamExecutedCommandBase(ITeam user, ISpiteAction action) : base(action)
		{
			Executor = user;
		}
	}
}
