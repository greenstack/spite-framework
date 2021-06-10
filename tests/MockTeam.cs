using System.Collections.Generic;
using Spite.Interaction;
using Spite.UnitTests.Mocks;

namespace Spite.UnitTests
{
    /// <summary>
    /// A mock team object.
    /// </summary>
    class MockTeam : ITappableTeammateTeam<MockTappableTeammate>, ICommandExecutor
    {
        public TeamStanding CurrentStanding => TeamStanding.Inactive;

		private readonly List<ITappableTeammate> teammates = new List<ITappableTeammate>();
		public ICollection<ITappableTeammate> Members => teammates;

		public int ManagedEntityCount => teammates.Count;

		public ITeam ResponsibleTeam => this;

		public void AddEntity(ITappableTeammate entity)
		{
			teammates.Add(entity);
		}

		public TeamStanding DetermineStanding(IArena context)
        {
            return CurrentStanding;
        }

        public void ForceStanding(TeamStanding standing)
        {
            throw new System.NotImplementedException();
        }

		public void InitializeEntityCount(uint entityCount)
		{
			throw new System.NotImplementedException();
		}
	}
}