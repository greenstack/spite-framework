using System;
using Spite;

namespace SpiteBattleship
{
    class ShipEntity : ITeammate
    {

        public ITeam Team => throw new NotImplementedException();

        public bool IsAlive => Health > 0;

        public int Health { get; private set; }

        public string Name { get; }

        public ShipEntity(string name, int segments)
        {
            Health = segments;
            Name = name;
        }

        public void TakeHit()
        {
            --Health;
        }
    }
}
