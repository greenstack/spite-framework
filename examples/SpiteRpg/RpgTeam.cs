using Spite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteRpg
{
    class RpgTeam : ITeam
    {
        public ICollection<IEntity> Entities => throw new NotImplementedException();

        public int ManagedEntityCount => throw new NotImplementedException();

        public TeamStanding CurrentStanding => throw new NotImplementedException();

        public void AddEntity(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public TeamStanding DetermineStanding(IArena context)
        {
            throw new NotImplementedException();
        }

        public void ForceStanding(TeamStanding standing)
        {
            throw new NotImplementedException();
        }

        public void InitializeEntityCount(uint entityCount)
        {
            throw new NotImplementedException();
        }
    }
}
