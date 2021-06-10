namespace Spite.UnitTests.Mocks
{
	public class MockTeammate : ITeammate
	{
		public ITeam Team { get; }

		public TeammateStatus Status => TeammateStatus.Active;

		public MockTeammate(ITeam team)
		{
			Team = team;
		}
	}
}
