using Spite.Interaction;
using Spite.Turns;

namespace Spite.UnitTests.Mocks.Turns
{
    public class AlwaysExecutableTurnPhase : ITurnPhase
    {
        public event ChangePhase OnPhaseChanged;

        public void ChangePhase(ITurnManager manager)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCommandExecutableThisPhase(CommandBase command)
        {
            return true;
        }
    }
}
