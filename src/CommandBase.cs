namespace Spite
{
    /// <summary>
    /// Provides a basic structure and implementation for commands.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public IActor Owner { get; }
        
        public IArena Context { get; }

        public abstract bool ShouldUpdateTeamStandings { get; }


        public CommandBase(IActor owner, IArena context)
        {
            Owner = owner;
            Context = context;
        }

        public abstract bool Execute();
    }
}
