using Spite.Turns;

namespace Spite.UnitTests.Mocks
{
    class MockTurnManager : TurnManagerBase
    {
        public MockTurnManager(bool executeFollowUpsIfActionFailed) : base(executeFollowUpsIfActionFailed)
        {
        }
    }
}