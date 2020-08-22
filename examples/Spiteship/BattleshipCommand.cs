using Spite;

namespace SpiteBattleship
{
    /// <summary>
    /// Provides a basic starter class for Battleship commands
    /// </summary>
    abstract class BattleshipCommand : ICommand<BattleshipTurnManager>
    {
        public IActor Owner { get; }
        public abstract bool ShouldUpdateTeamStandings { get; }

        public BattleshipTurnManager Context { get; }

        public BattleshipCommand(BattleshipTurnManager context, IActor<BattleshipTeam> owner)
        {
            Context = context;
            Owner = owner;
        }

        abstract public bool Execute();
    }
}
