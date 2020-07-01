using Spite;

namespace SpiteRpg
{
    class RpgEntity : ITappableEntity
    {
        public ITeam Team { get; }

        public bool IsAlive => throw new System.NotImplementedException();

        public bool Tapped => throw new System.NotImplementedException();

        public event Untap OnUntap;
        public event Tap OnTapped;

        public RpgEntity(ITeam team)
        {
            Team = team;
        }
    }
}
