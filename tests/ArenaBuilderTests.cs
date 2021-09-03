using Spite.Turns;
using NUnit.Framework;
using System.Collections;

namespace Spite.UnitTests
{
	public class ArenaBuilderTests
	{
		ArenaBuilder<MockTeam> MockTeamArenaBuilder;

		MockTeam TeamA;

		MockTeam TeamB;

		[SetUp]
		public void SetUp()
		{
			TeamA = new MockTeam();
			TeamB = new MockTeam();
			MockTeamArenaBuilder = new ArenaBuilder<MockTeam>()
				.SetTeamCount(2)
				.AddTeam(TeamA)
				.AddTeam(TeamB)
				.SetTurnScheme(TurnSchemeType.DiscreteTeam)
				// TODO: If a test case requires this to be different,
				// we should this in the individual test case.
				.SetBattleOverCondition(() => false);
		}

		[Test]
		public void TestSetTeamCountAndTeamAddition()
		{
			// Uses the arena builder created in the setup method
			Arena a = MockTeamArenaBuilder.Finish();
			Assert.AreEqual(2, a.TeamCount);
			var teamC = new MockTeam();
			Assert.Throws<System.InvalidOperationException>(() =>
			{
				MockTeamArenaBuilder.AddTeam(teamC);
			});

			var unlimitedTeamArenaBuilder = new ArenaBuilder<MockTeam>()
				.AddTeam(TeamA)
				.AddTeam(TeamB)
				.AddTeam(teamC)
				.SetTurnScheme(TurnSchemeType.DiscreteTeam)
				.SetBattleOverCondition(() => false);

			a = unlimitedTeamArenaBuilder.Finish();
			Assert.AreEqual(3, a.TeamCount);
			var teams = (ICollection)a.Teams;
			Assert.Contains(TeamA, teams);
			Assert.Contains(TeamB, teams);
			Assert.Contains(teamC, teams);
		}

		[Test]
		public void TestSetArenaName()
		{
			const string ArenaName = "T";
			MockTeamArenaBuilder.SetArenaName(ArenaName);
			Arena a = MockTeamArenaBuilder.Finish();
			Assert.AreEqual(ArenaName, a.ArenaName);
		}

		[Test]
		public void TestSetTurnSchemeToDiscrete()
		{
			// One of the things we want to be sure about is that the team order is
			// retained after choosing the scheme	
			Arena a = MockTeamArenaBuilder.Finish();
			var turnManager = a.TurnManager;
			Assert.IsInstanceOf<DiscreteTeamTurnManager>(turnManager);
			var asDTTM = (DiscreteTeamTurnManager)turnManager;
			Assert.AreEqual(TeamA, asDTTM.CurrentTeam);
		}
	}
}
