namespace Spite
{
    /// <summary>
    /// Provides a basic structure and implementation for commands.
    /// </summary>
    public abstract class CommandBase<TContext> : ICommand<TContext>
    {
        public IActor Owner { get; }
        
        public TContext Context { get; }

        public abstract bool ShouldUpdateTeamStandings { get; }


        public CommandBase(IActor owner, TContext context)
        {
            Owner = owner;
            Context = context;
        }

        public abstract bool Execute();
    }
}
