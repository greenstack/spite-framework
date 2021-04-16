namespace Spite.Interaction
{
    /// <summary>
    /// Represents a command executed by a team.
    /// </summary>
    public interface ITeamExecutedCommand : ISpiteCommand
    {
        /// <summary>
        /// The team executing this command.
        /// </summary>
        ITeam Executor { get; }
    }
}
