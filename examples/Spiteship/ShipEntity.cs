using System;
using Spite;

namespace SpiteBattleship
{
    class ShipEntity : IEntity
    {

        public ITeam Team => throw new NotImplementedException();

        public bool IsAlive => Health > 0;

        public int Health { get; private set; }

        public string Name { get; }

        public ShipEntity(string name, int health)
        {
            Health = health;
            Name = name;
        }

        void TakeHit()
        {
            --Health;
        }
    }
}
