namespace Spite
{
    /// <summary>
    /// Provides some basic common functionality for commands.
    /// </summary>
    /// <typeparam name="TContext">The type of object this command will operate on.</typeparam>
    public abstract class Command<TContext> : ICommand<TContext>
    {
        /// <inheritdoc/>
        public IActor Owner { get; }
        
        /// <inheritdoc/>
        public TContext Context { get; }

        /// <inheritdoc/>
        public abstract bool ShouldUpdateTeamStandings { get; }

        /// <summary>
        /// Builds a basic command object.
        /// </summary>
        /// <param name="owner">The owner of this command.</param>
        /// <param name="context">The context this command will be operating on.</param>
        public Command(IActor owner, TContext context)
        {
            Owner = owner;
            Context = context;
        }

        /// <inheritdoc/>
        public abstract bool Execute();
    }
}
