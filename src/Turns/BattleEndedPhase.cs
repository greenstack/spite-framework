using Spite.Interaction;

namespace Spite.Turns
{
    /// <summary>
    /// Represents a battle that has ended. This is the canonical "end of
    /// battle" phase, but it can be extended to suit your needs.
    /// </summary>
    class BattleEndedPhase : ITurnPhase
    {
        public event ChangePhase OnPhaseChanged;

        public void ChangePhase(ITurnManager manager)
        {
            // Do nothing. The battle is over; there is nothing to do.
        }

        public bool IsCommandExecutableThisPhase(CommandBase command)
        {
            // No commands can be executed once the battle is over.
            return false;
        }
    }
}
