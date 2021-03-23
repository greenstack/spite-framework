namespace Spite.UnitTests
{
    /// <summary>
    /// A mock team object.
    /// </summary>
    class MockTeam : ITeam
    {
        public TeamStanding CurrentStanding => TeamStanding.Inactive;

        public TeamStanding DetermineStanding(IArena context)
        {
            return CurrentStanding;
        }

        public void ForceStanding(TeamStanding standing)
        {
            throw new System.NotImplementedException();
        }
    }
}