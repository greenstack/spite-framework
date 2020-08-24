namespace Spite
{
    /// <summary>
    /// Provides an interface for delivering commands.
    /// </summary>
    /// <typeparam name="TContext">The type of object that the command will operate on.</typeparam>
    public interface ICommand<TContext>
    {
        /// <summary>
        /// The actor performing this command.
        /// </summary>
        IActor Owner { get; }

        /// <summary>
        /// The object that this command will be operating on.
        /// </summary>
        TContext Context { get; }

        /// <summary>
        /// Should the arena update the team standings if this command is successful?
        /// </summary>
        bool ShouldUpdateTeamStandings { get; }
        
        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <returns>True if the command was properly executed.</returns>
        bool Execute();

    }
}
