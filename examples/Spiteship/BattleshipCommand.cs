using Spite;

namespace SpiteBattleship
{
    /// <summary>
    /// Provides a basic starter class for Battleship commands
    /// </summary>
    abstract class BattleshipCommand : ICommand
    {
        public IActor Owner { get; }
        public abstract bool ShouldUpdateTeamStandings { get; }

        public BattleshipCommand(IActor<BattleshipTeam> owner)
        {
            Owner = owner;
        }

        abstract public bool Execute();
    }
}
