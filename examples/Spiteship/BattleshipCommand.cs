using Spite;

namespace SpiteBattleship
{
    /// <summary>
    /// Provides a basic starter class for Battleship commands
    /// </summary>
    abstract class BattleshipCommand : ICommand
    {
        public IActor Owner { get; }

        public BattleshipCommand(IActor owner)
        {
            Owner = owner;
        }

        abstract public bool Execute();
    }
}
