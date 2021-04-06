namespace Spite.Interaction
{
    /// <summary>
    /// A basic command being issued to an ally.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// The teammate using the action.
        /// </summary>
        public ITeammate User => action.User;

        /// <summary>
        /// The action to be taken by this command.
        /// </summary>
        protected readonly ISpiteAction action;

        /// <summary>
        /// Constructs the basic command.
        /// </summary>
        /// <param name="action">The action being performed by this command</param>
        public Command(ITeammate user, ISpiteAction action)
        {
            this.action = action;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <typeparam name="T">The expected type of reaction data.</typeparam>
        /// <returns>The reaction data.</returns>
        public abstract IReaction<T> Execute<T>() where T : struct;

        /// <summary>
        /// Checks if the command is valid.
        /// </summary>
        /// <returns>True if the command and the action is valid.</returns>
        public virtual bool IsValid()
        {
            return action.IsValid();
        }
    }
}
