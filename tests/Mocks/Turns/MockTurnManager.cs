using Spite.Turns;

namespace Spite.UnitTests.Mocks.Turns
{
    class MockTurnManager : TurnManagerBase
    {
        public MockTurnManager(bool executeFollowUpsIfActionFailed) : base(new AlwaysExecutableTurnPhase(), executeFollowUpsIfActionFailed) {}
    }
}