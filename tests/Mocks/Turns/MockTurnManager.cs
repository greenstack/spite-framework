using Spite.Turns;

namespace Spite.UnitTests.Mocks.Turns
{
    class MockTurnManager : TurnManagerBase
    {
        public MockTurnManager(bool executeFollowUpsIfActionFailed) : base(executeFollowUpsIfActionFailed)
        {
            CurrentPhase = new AlwaysExecutableTurnPhase();
        }
    }
}