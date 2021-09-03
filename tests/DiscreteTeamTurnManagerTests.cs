using NUnit.Framework;
using System.Collections.Generic;
using Spite.Turns;
using Spite.Interaction;
using Spite.UnitTests.Mocks;
using Spite.UnitTests.Mocks.Interaction;
using Spite.UnitTests.Mocks.Turns;

namespace Spite.UnitTests
{
    /// <summary>
    /// Performs various tests on the DiscreteTeamTurnManager. These tests also test TeamPhase.
    /// </summary>
    public class DiscreteTeamTurnManagerTests
    {
        MockTeam teamA;
        MockTeam teamB;
        
        DiscreteTeamTurnManager<MockTeam> turnManager;

        [SetUp]
        public void SetUp()
		{
            teamA = new MockTeam();
            teamB = new MockTeam();
            turnManager = new DiscreteTeamTurnManager<MockTeam>(new List<MockTeam> { teamA, teamB });
        }

        [Test]
        public void TestConstruction()
		{
            // Make sure that turnManager.CurrentTeam and the phase's team are the same.
            Assert.AreEqual(teamA, turnManager.CurrentTeam);
            Assert.AreEqual(teamA, (turnManager.CurrentPhase as TeamPhase).CurrentTeam);
		}

        [Test]
        public void TestIsCommandExecutable()
		{
            CommandBase action = new AlwaysFailActionCommand(teamA, new AlwaysFailAction());
            Assert.IsTrue(turnManager.IsCommandExecutable(action));
		}

        [Test]
        public void TestAutoPhaseAdvancement()
		{
            MockTappableTeammate mtt = new MockTappableTeammate(teamA);
            teamA.AddEntity(mtt);
            CommandBase command = new TapCommand(mtt, teamA);

            var arena = new ArenaBuilder<MockTeam>()
                .AddTeam(new MockTeam())
                .SetTurnManager(turnManager)
                .SetBattleOverCondition(() => false)
                .Finish();

            turnManager.AcceptCommand(command, arena);

            Assert.IsFalse(turnManager.IsCommandExecutable(command));
            Assert.AreEqual(teamB, turnManager.CurrentTeam);
		}
    }
}
