using System.Collections.Generic;
using System.Linq;
using Spite.Interaction;
using Spite.UnitTests.Mocks;

namespace Spite.UnitTests
{
    /// <summary>
    /// A mock team object.
    /// </summary>
    class MockTeam : ITeamOfTappables<MockTappableTeammate>, ICommandExecutor
    {
        public TeamStanding CurrentStanding => TeamStanding.Inactive;

		private readonly List<MockTappableTeammate> teammates = new List<MockTappableTeammate>();
		public ICollection<MockTappableTeammate> Members => teammates;

		public int ManagedEntityCount => teammates.Count;

		public ITeam ResponsibleTeam => this;

		public int TappedUnitCount => Members.Count(teammate => teammate.IsTapped);

		public void AddEntity(MockTappableTeammate entity)
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

		public void TapAll()
		{
			teammates.ForEach(teammate => teammate.Tap());
		}

		public void UntapAll()
		{
			teammates.ForEach(teammate => teammate.Untap());
		}
	}
}