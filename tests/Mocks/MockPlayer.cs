using System.Collections.Generic;
using Spite.Turns;

namespace Spite.UnitTests.Mocks
{
	public class MockPlayer : ITeamExecutor<MockTeammate>
	{
		private readonly List<MockTeammate> teammates = new List<MockTeammate>();
		public IList<MockTeammate> Members => teammates;

		public TeamStanding CurrentStanding {get; set;} = TeamStanding.Inactive;

		public int ManagedEntityCount => Members.Count;

		public ITeam ResponsibleTeam => this;

		public void AddEntity(MockTeammate entity)
		{
			teammates.Add(entity);
		}

		public TeamStanding DetermineStanding(IArena context)
		{
			return CurrentStanding;
		}

		public void ForceStanding(TeamStanding standing)
		{
			CurrentStanding = standing;
		}

		public void InitializeEntityCount(uint entityCount)
		{
			throw new System.NotImplementedException();
		}
	}
}