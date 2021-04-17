namespace Spite.Interaction
{
    /// <summary>
    /// A basic command.
    /// </summary>
    public abstract class CommandBase : ISpiteCommand
    {
        /// <summary>
        /// The action to be taken by this command.
        /// </summary>
        internal readonly ISpiteAction action;

        /// <inheritdoc/>
		public object Executor { get; }

		/// <summary>
		/// Constructs the basic command. It is recommended that base classes don't
        /// require the executor parameter to be of the same type, but that it be
        /// of the type of object executing the command.
		/// </summary>
		/// <param name="action">The action being performed by this command</param>
		/// <param name="executor">The object executing the command.</param>
		public CommandBase(ISpiteAction action, object executor)
        {
            this.action = action;
            Executor = executor;
        }

        /// <inheritdoc/>
        public virtual IReaction Execute() => action.UseAndGetReaction();

        /// <inheritdoc/>
        public TReactionType Execute<TReactionType>() 
            where TReactionType : IReaction
            => (TReactionType)Execute();

        /// <inheritdoc/>
        public virtual bool IsValid()
        {
            return action.IsValid();
        }
    }
}
