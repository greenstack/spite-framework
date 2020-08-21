using Spite;
using Spite.Queries;
using System;
using System.Threading;


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
                = new PlayerBattleshipController(player);

            var battleshipManager = new BattleshipTurnManager(playerContoller);

            PlayerPhase.player = playerContoller;

            arena = new ArenaBuilder<BattleshipTeam>()
                .SetArenaName("battleship")
                .SetTurnManager(battleshipManager)
                .SetTeamCount(2)
                .AddTeam(player)
                .AddTeam(AI)
                .Finish();

            arena.StartBattle();
            bool quit;
            do
            {
                string input = Console.ReadLine();
                quit = input.ToLower() == "q";

                char[] coords = input.ToCharArray();
                char column, row;
                if (char.IsLetter(coords[0]))
                {
                    // i.e. J1
                    row = coords[0];
                    column = coords[1];
                }
                else
                {
                    // i.e. 1J
                    row = coords[1];
                    column = coords[0];
                }

                int x = int.Parse(column.ToString());
                int y = char.ToUpper(row) - 0x41;

                // TODO: Input validation

                // Yikes @ PlayerPhase.player
                var guess = new GuessCommand(PlayerPhase.player, AI, x, y);

                arena.ReceiveAndExecuteCommand(guess);

            } while (!arena.AnyTeamHasStanding(TeamStanding.Eliminated) && !quit);
        }

        /// <summary>
        /// Builds a simple side for battleship.
        /// </summary>
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
