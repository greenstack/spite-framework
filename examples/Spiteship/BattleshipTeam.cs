using Spite;
using Spite.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpiteBattleship
{
    class BattleshipTeam : ITeam<ShipEntity>
    {
        ShipEntity[] ships;

        const int PATROL_BOAT_INDEX = 0;
        const int SUBMARINE_INDEX = 1;
        const int DESTROYER_INDEX = 2;
        const int BATTLESHIP_INDEX = 3;
        const int CARRIER_INDEX = 4;
        const int BOARD_DIMENSIONS = 10;

        private readonly Dictionary<string, int> ShipIndex = new Dictionary<string, int>()
        {
            {"Patrol Boat", PATROL_BOAT_INDEX },
            {"Submarine", SUBMARINE_INDEX },
            {"Destroyer", DESTROYER_INDEX },
            {"Battleship", BATTLESHIP_INDEX },
            {"Carrier", CARRIER_INDEX },
        };

        /// <summary>
        /// null = no guess
        /// false = miss
        /// true = hit
        /// </summary>
        private bool?[,] Guesses = new bool?[BOARD_DIMENSIONS, BOARD_DIMENSIONS];
        /// <summary>
        /// The locations of the ships.
        /// </summary>
        private ShipSegment[,] shipsSegments = new ShipSegment[BOARD_DIMENSIONS, BOARD_DIMENSIONS];

        public int ManagedEntityCount => ships.Length;

        public TeamStanding CurrentStanding { get; private set; } = TeamStanding.Competing;

        public ICollection<ShipEntity> Entities => ships;

        /// <summary>
        /// Causes the team to take a shot.
        /// </summary>
        /// <param name="x">The x coordinate of the shot.</param>
        /// <param name="y">The y coordinate of the shot.</param>
        /// <returns>True if the shot results in a hit.</returns>
        public bool ReceiveGuess(int x, int y)
        {
            var ship = shipsSegments[x, y].Ship;
            if (ship != null && ship.IsAlive)
            {
                ship.TakeHit();
                Console.WriteLine($"Hit! @ {x}, {y}");
                return true;
            }
            Console.WriteLine($"Miss! @ {x}, {y}");
            return false;
        }

        public void AddEntity(ShipEntity ship)
        {
            int index = ShipIndex[ship.Name];
            ships[index] = ship;
            switch (index)
            {
                case PATROL_BOAT_INDEX:
                    shipsSegments[0, 0] = new ShipSegment(ship);
                    shipsSegments[0, 1] = new ShipSegment(ship);
                    break;
                case SUBMARINE_INDEX:
                    shipsSegments[3, 2] = new ShipSegment(ship);
                    shipsSegments[4, 2] = new ShipSegment(ship);
                    shipsSegments[5, 2] = new ShipSegment(ship);
                    break;
                case DESTROYER_INDEX:
                    shipsSegments[7, 4] = new ShipSegment(ship);
                    shipsSegments[7, 5] = new ShipSegment(ship);
                    shipsSegments[7, 6] = new ShipSegment(ship);
                    break;
                case BATTLESHIP_INDEX:
                    shipsSegments[1, 4] = new ShipSegment(ship);
                    shipsSegments[1, 5] = new ShipSegment(ship);
                    shipsSegments[1, 6] = new ShipSegment(ship);
                    shipsSegments[1, 7] = new ShipSegment(ship);
                    break;
                case CARRIER_INDEX:
                    shipsSegments[4, 8] = new ShipSegment(ship);
                    shipsSegments[5, 8] = new ShipSegment(ship);
                    shipsSegments[6, 8] = new ShipSegment(ship);
                    shipsSegments[7, 8] = new ShipSegment(ship);
                    shipsSegments[8, 8] = new ShipSegment(ship);
                    break;
                default:
                    throw new Exception($"Invalid index: {index}");
            }
        }

        /// <summary>
        /// Sets the number of ships available to the side.
        /// </summary>
        /// <param name="entityCount">The number of entities to initialize.</param>
        public void InitializeEntityCount(uint entityCount)
        {
            ships = new ShipEntity[entityCount];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Your side:\n");
            for (int y = 0; y < BOARD_DIMENSIONS; ++y)
            {
                for (int x = 0; x < BOARD_DIMENSIONS; ++x)
                {
                    builder.Append(shipsSegments[x, y].ToString());
                }
                builder.Append("\n");
            }
            builder.Append("Your guesses:\n");
            for (int y = 0; y < BOARD_DIMENSIONS; ++y)
            {
                for (int x = 0; x < BOARD_DIMENSIONS; ++x)
                {
                    string tile;
                    if (Guesses[x, y] == null)
                        tile = ".";
                    else if (Guesses[x, y] == false)
                        tile = "O";
                    else
                        tile = "X";
                    builder.Append(tile);
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }

        public TeamStanding DetermineStanding(IArena context)
        {
            if (!this.AreAnyEntitiesAlive())
            {
                CurrentStanding = TeamStanding.Eliminated;
                return CurrentStanding;
            }
            var opponent = context.GetOpposingTeam(this);
            CurrentStanding = opponent.AreAnyEntitiesAlive() ? TeamStanding.Competing : TeamStanding.Victorious;
            return CurrentStanding;
        }

        /// <summary>
        /// Tells the team that a guess was made at a coordinate.
        /// </summary>
        /// <param name="x">The x coordinate of the guess.</param>
        /// <param name="y">The y coordinate of the guess.</param>
        /// <param name="hit">Whether or not the guess was a successful hit.</param>
        public void InformOfGuessAt(int x, int y, bool hit)
        {
            Guesses[x, y] = hit;
        }

        public bool DidGuessAt(int x, int y)
        {
            return Guesses[x, y] != null;
        }

        public void ForceStanding(TeamStanding standing)
        {
            CurrentStanding = standing;
        }
    }
}
