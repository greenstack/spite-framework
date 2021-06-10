using Spite.Turns;
using NUnit.Framework;

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
			MockTeamArenaBuilder = new ArenaBuilder<MockTeam>();
			TeamA = new MockTeam();
			TeamB = new MockTeam();
			MockTeamArenaBuilder.SetTeamCount(2);
			MockTeamArenaBuilder.AddTeam(TeamA);
			MockTeamArenaBuilder.AddTeam(TeamB);
			MockTeamArenaBuilder.SetTurnScheme(TurnSchemeType.DiscreteTeam);
		}

		[Test]
		public void TestSetTeamCountAndTeamAddition()
		{
			// Uses the arena builder created in the setup method
			Arena a = MockTeamArenaBuilder.Finish();
			Assert.AreEqual(2, a.TeamCount);
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
