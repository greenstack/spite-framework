using NUnit.Framework;
using Spite.Interaction;
using Spite.UnitTests.Mocks.Interaction;
using Spite.UnitTests.Mocks.Turns;

namespace Spite.UnitTests
{
    public class TurnManagerTests
    {
        [Test]
        [TestCase(true, 1, typeof(AlwaysFailAction))]
        [TestCase(true, 2, typeof(AlwaysFailAndHaveFollowUpAction))]
        [TestCase(false, 1, typeof(AlwaysFailAction))]
        [TestCase(false, 1, typeof(AlwaysFailAndHaveFollowUpAction))]
        public void TestAcceptCommand(bool shouldExecuteFollowUps, int expectedFollowUpResultCount, System.Type actionType)
        {
            MockTurnManager mtm_true = new MockTurnManager(shouldExecuteFollowUps);
            ISpiteAction action = (ISpiteAction)System.Activator.CreateInstance(actionType);
            IReaction[] results = mtm_true.AcceptCommand(new AlwaysFailActionCommand(null, action));
            
            Assert.IsNotEmpty(results);
            Assert.AreEqual(results.Length, expectedFollowUpResultCount);
        }
    }
}
