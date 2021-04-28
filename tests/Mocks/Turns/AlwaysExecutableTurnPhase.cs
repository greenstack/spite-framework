using Spite.Interaction;
using Spite.Turns;

namespace Spite.UnitTests.Mocks.Turns
{
    public class AlwaysExecutableTurnPhase : ITurnPhase
    {
        public event ChangePhase OnPhaseChanged;

        public void GetNextPhase(ITurnManager manager)
        {
            throw new System.NotImplementedException();
        }

		public ITurnPhase GetNextPhase()
		{
			// There is no other phase. Let's just return itself.
			return this;
		}

		public bool IsCommandExecutableThisPhase(CommandBase command)
        {
            return true;
        }

		public bool ShouldAdvancePhase(IReaction[] results)
		{
			return false;
		}
	}
}
