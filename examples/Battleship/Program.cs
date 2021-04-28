using System;
using Spite;
using Spite.Turns;

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

        static BattleshipTeam currentTeam;

        static void Main()
        {
            bool continuePlaying = true;
            do
            {    
                Arena arena = BuildArena();

                do
                {
                    // Get the current player's command
                    var command = currentTeam.GetCommand();
                    // Pass it to the arena
                    var results = arena.ReceiveAndExecuteCommand(command);

                    // Process the results
                    foreach (var result in results)
					{
                        Console.WriteLine(result.ToString());
					}

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

        static Arena BuildArena()
		{
            PlayerBattleshipTeam playerTeam = new TeamBuilder<PlayerBattleshipTeam, Ship>()
                .Start()
                .SetTeamSize(3)
                .AddEntity(new Ship("Carrier", CarrierSize))
                .AddEntity(new Ship("Battleship", BattleshipSize))
                .AddEntity(new Ship("Patrol Boat", PatrolBoatSize))
                .Finish();
            playerTeam.PrepareBoard();
            currentTeam = playerTeam;

            EnemyBattleshipTeam enemyTeam = new TeamBuilder<EnemyBattleshipTeam, Ship>()
                .Start()
                .SetTeamSize(3)
                .AddEntity(new Ship("Carrier", CarrierSize))
                .AddEntity(new Ship("Battleship", BattleshipSize))
                .AddEntity(new Ship("Patrol Boat", PatrolBoatSize))
                .Finish();
            enemyTeam.PrepareBoard();

            // I guess alliance graphs aren't really all that useful for 2-sided games.
            // More for games with multiple sides and complex relationships
            playerTeam.Opponent = enemyTeam;
            enemyTeam.Opponent = playerTeam;

            BattleshipTurnManager turnManager = new BattleshipTurnManager(playerTeam, enemyTeam);

			turnManager.OnPhaseChanged += TurnManager_OnPhaseChanged;

            return new ArenaBuilder<BattleshipTeam>()
                // The battleship turn manager also sets up the phases
                .SetTurnManager(turnManager)
                // This will probably be removed in 0.3.0-alpha, replaced with a "SetMaxTeamCount" method
                .SetTeamCount(2)
                // Add the teams that are participating in this game
                .AddTeam(playerTeam)
                .AddTeam(enemyTeam)
                // Set up the relationship between the teams. Not crucial in this scenario, but still important.
                .AddBidirectionalTeamRelationship(playerTeam, enemyTeam, TeamRelationship.Opposing)
                // Get the actual arena
                .Finish();
        }

		private static void TurnManager_OnPhaseChanged(ITurnPhase fromPhase, ITurnPhase toPhase, ITurnManager turnManager)
		{
            if (toPhase is EnemyPhase ePhase)
            {
                currentTeam = ePhase.EnemyTeam;
            }
            else if (toPhase is PlayerPhase pPhase)
			{
                currentTeam = pPhase.PlayerTeam;
			}
		}
	}
}
