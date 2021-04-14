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
        /// <param name="user">The user responsible for this command.</param>
        /// <param name="action">The action being performed by this command</param>
        public CommandBase(ITeammate user, ISpiteAction action)
        {
            this.action = action;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>The reaction data.</returns>
        public abstract IReaction Execute();

        /// <summary>
        /// Executes the command and casts the result to the expected reaction type.
        /// </summary>
        /// <typeparam name="TReactionType">The expected type of reaction data.</typeparam>
        /// <returns>The reaction data.</returns>
        public TReactionType Execute<TReactionType>() 
            where TReactionType : IReaction
            => (TReactionType)Execute();

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
