using System;
using Spite;

namespace Battleship
{
    class Program
    {
        /// <summary>
        /// The number of segments a carrier has.
        /// </summary>
        const int CarrierSize = 5;
        /// <summary>
        /// The number of segments a battleship has.
        /// </summary>
        const int BattleshipSize = 4;
        /// <summary>
        /// The number of segments a patrol boat has.
        /// </summary>
        const int PatrolBoatSize = 2;

        static void Main()
        {
            Console.WriteLine("Hello World!");

            BattleshipTeam playerTeam = new TeamBuilder<BattleshipTeam, Ship>()
                .SetTeamSize(3)
                .AddEntity(new Ship("Carrier", CarrierSize))
                .AddEntity(new Ship("Battleship", BattleshipSize))
                .AddEntity(new Ship("Patrol Boat", PatrolBoatSize))
                .Finish();

            BattleshipTeam enemyTeam = new TeamBuilder<BattleshipTeam, Ship>()
                .SetTeamSize(3)
                .AddEntity(new Ship("Carrier", CarrierSize))
                .AddEntity(new Ship("Battleship", BattleshipSize))
                .AddEntity(new Ship("Patrol Boat", PatrolBoatSize))
                .Finish();

            Arena arena = new ArenaBuilder<BattleshipTeam>()
                .SetTeamCount(2)
                .AddTeam(playerTeam)
                .AddTeam(enemyTeam)
                .AddBidirectionalTeamRelationship(playerTeam, enemyTeam, TeamRelationship.Opposing)
                .Finish();

            bool continuePlaying = true;
            do
            {
                do
                {
                    // Get the current player's command
                    // Pass it to the arena
                    // Process the results
                } while (!arena.IsBattleOver);

                Console.WriteLine("The battle is over!");

                // Check if the player wants to continue;
                bool invalidInput = true;
                while (invalidInput)
                {
                    Console.WriteLine("Would you like to play again? Y/N");
                    var key = Console.ReadKey(false);
                    if (key.KeyChar == 'y')
                    {
                        // Break out of the loop and continue
                        invalidInput = false;
                    }
                    else if (key.KeyChar == 'n')
                    {
                        // Nope, no continue.
                        continuePlaying = false;
                        break;
                    }
                }
                

            } while (continuePlaying);

            Console.WriteLine("Thanks for playing!");
        }
    }
}
