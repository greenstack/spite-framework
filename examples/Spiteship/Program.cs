using Spite;
using Spite.Queries;
using System;

namespace SpiteBattleship
{
    /// <summary>
    /// This program uses Spite to build a game of battleship. This isn't a
    /// stellar implementation, nor is it supposed to be a fun one. It's one
    /// purpose is to show how one could go about building battleship using the
    /// Spite framework, starting with building teams, an arena, and a basic
    /// gameplay loop.
    /// </summary>
    class Program
    {
        const int SHIPS_PER_SIDE = 5;

        static private Arena arena;

        static private BattleshipTeam player;

        static private BattleshipTeam AI;

        static void Main(string[] args)
        {
            player = BuildTeam();
            AI = BuildTeam();

            PlayerBattleshipController playerContoller
                = new PlayerBattleshipController(player, AI);

            var battleshipManager = new BattleshipTurnManager(playerContoller);

            // Yikes @ this
            PlayerPhase.player = playerContoller;

            arena = new ArenaBuilder<BattleshipTeam>()
                .SetArenaName("battleship")
                .SetTurnManager(battleshipManager)
                .SetTeamCount(2)
                .AddTeam(player)
                .AddTeam(AI)
                .Finish();

            arena.StartBattle();
            Console.WriteLine("Welcome to Battleship!");
            do
            {
                Console.Write(player.ToString());

                var action = battleshipManager.CurrentController.GetAction(battleshipManager);

                arena.ReceiveAndExecuteCommand(action);
            } while (!arena.AnyTeamHasStanding(TeamStanding.Eliminated));

            if (player.CurrentStanding == TeamStanding.Victorious)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat!");
            }
            Console.Write("Press any key to continue.");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Builds a simple side for battleship.
        /// </summary>ssssssssssssssssssss
        /// <returns>A battleship team.</returns>
        static BattleshipTeam BuildTeam()
        {
            TeamBuilder<BattleshipTeam, ShipEntity> builder = new TeamBuilder<BattleshipTeam, ShipEntity>();
            return builder.Start()
                .SetTeamSize(SHIPS_PER_SIDE)
                .AddEntity(new ShipEntity("Carrier", 5))
                .AddEntity(new ShipEntity("Battleship", 4))
                .AddEntity(new ShipEntity("Destroyer", 3))
                .AddEntity(new ShipEntity("Submarine", 3))
                .AddEntity(new ShipEntity("Patrol Boat", 2))
                .Finish();
        }
    }
}
