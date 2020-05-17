using Spite;

namespace SpiteBattleship
{
    class Program
    {
        const int SHIPS_PER_SIDE = 5;

        static private Arena arena;

        static private ITeam player;

        static private ITeam AI;

        static void Main(string[] args)
        {
            player = BuildTeam();
            AI = BuildTeam();

            arena = new ArenaBuilder()
                .InitArena("battleship", 2)
                .SetTurnScheme(TurnScheme.Team)
                .AddTeam(player)
                .AddTeam(AI)
                .Finish();
        }

        /// <summary>
        /// Builds a simple side for battleship.
        /// </summary>
        /// <returns></returns>
        static BattleshipTeam BuildTeam()
        {
            TeamBuilder builder = new TeamBuilder();
            builder.Start<BattleshipTeam>()
                .SetTeamSize(SHIPS_PER_SIDE)
                .AddEntity(new ShipEntity("Carrier", 5))
                .AddEntity(new ShipEntity("Battleship", 4))
                .AddEntity(new ShipEntity("Destroyer", 3))
                .AddEntity(new ShipEntity("Submarine", 3))
                .AddEntity(new ShipEntity("Patrol Boat", 2));
            return builder.Finish<BattleshipTeam>();
        }
    }
}
