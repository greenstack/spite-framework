namespace Spite
{
    /// <summary>
    /// Provides an interface for delivering commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The actor performing this command.
        /// </summary>
        IActor Owner { get; }
        
        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <returns>True if the command was properly executed.</returns>
        bool Execute();
    }
}
