using NUnit.Framework;
using Spite.Turns;
using Spite.Interaction;
using Spite.UnitTests.Mocks;

namespace Spite.UnitTests
{
	class TapAllInteractionTests
	{
		MockTeam teamA;

		MockTeam teamB;

		Arena arena;

		[SetUp]
		public void SetUp()
		{
			teamA = new MockTeam();
			teamA.AddEntity(new MockTappableTeammate(teamA));
			teamA.AddEntity(new MockTappableTeammate(teamB));

			teamB = new MockTeam();
			teamB.AddEntity(new MockTappableTeammate(teamB));
			teamB.AddEntity(new MockTappableTeammate(teamA));

			arena = new ArenaBuilder<MockTeam>()
				.AddTeam(teamA)
				.AddTeam(teamB)
				.SetTurnScheme(TurnSchemeType.DiscreteTeam)
				.SetBattleOverCondition(() => false)
				.Finish();
		}

		[Test]
		public void TestTapAllUnitsCommand()
		{
			var command = new TapAllTeammatesCommand(teamA);

			Assert.AreEqual(teamA, command.Executor);

			var reactions = arena.ReceiveAndExecuteCommand(command);
			Assert.AreEqual(1, reactions.Length);
			foreach (var reaction in reactions)
				Assert.IsInstanceOf<TapAllReaction>(reaction);
			
			foreach (var teammate in teamA.Members)
			{
				Assert.IsTrue(teammate.IsTapped);
			}

			// Just to be sure
			var turnManager = (DiscreteTeamTurnManager)arena.TurnManager;
			Assert.AreEqual(teamB, turnManager.CurrentTeam);
		}
	}
}
