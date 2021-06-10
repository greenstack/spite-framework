 namespace Spite.UnitTests.Mocks
{
	public class MockTappableTeammate : MockTeammate, ITappableTeammate
	{
		public MockTappableTeammate(ITeam team) : base(team)
		{
		}

		public bool IsTapped { get; private set; } = false;

		public void Tap()
		{
			IsTapped = true;
		}

		public void Untap()
		{
			IsTapped = false;
		}
	}
}
