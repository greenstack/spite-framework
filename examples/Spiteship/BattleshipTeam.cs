using Spite;

namespace SpiteBattleship
{
    class BattleshipTeam : ITeam
    {
        ShipEntity[] ships;

        public bool AreAllEntitiesTapped => throw new System.NotImplementedException();

        public int UntappedEntityCount => throw new System.NotImplementedException();

        public bool AreAllAlive => throw new System.NotImplementedException();

        public int AliveEntityCount => throw new System.NotImplementedException();

        public int ManagedEntityCount => throw new System.NotImplementedException();

        public TeamStanding CurrentStanding { get; private set; }

        public void AddEntity(IEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TeamStanding DetermineStanding(Arena context)
        {
            CurrentStanding = AreAllAlive ? TeamStanding.Competing : TeamStanding.Eliminated;
            return CurrentStanding;
        }

        /// <summary>
        /// Sets the number of ships available to the side.
        /// </summary>
        /// <param name="entityCount">The number of entities to initialize.</param>
        public void InitializeEntityCount(uint entityCount)
        {
            ships = new ShipEntity[entityCount];
        }
    }
}
