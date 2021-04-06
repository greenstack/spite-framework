namespace Spite.Interaction
{
    /// <summary>
    /// A basic command being issued to an ally.
    /// </summary>
    public abstract class CommandBase
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
        public CommandBase(ITeammate user, ISpiteAction action)
        {
            this.action = action;
        }

        public abstract IReaction Execute();

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <typeparam name="T">The expected type of reaction data.</typeparam>
        /// <returns>The reaction data.</returns>
        public abstract TReactionType Execute<TReactionType>() where TReactionType : IReaction;

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
