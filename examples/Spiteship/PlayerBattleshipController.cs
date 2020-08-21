using Spite;
using System;

namespace SpiteBattleship
{
    class PlayerBattleshipController : IActor
    {

        public ITeam Team { get => ConcreteTeam; }
        public BattleshipTeam ConcreteTeam { get; }

        public string Name => "player";

        public PlayerBattleshipController(BattleshipTeam playerTeam)
        {
            ConcreteTeam = playerTeam;
        }

        public bool askPlayerForInput(ref int x, ref int y)
        {
            bool invalidInput = true;
            do
            {
                Console.Clear();
                Console.Write(ConcreteTeam.ToString());
                Console.WriteLine("Enter an x, y coordinate to attack. (Q to quit)");

                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return true;
                }
                var coords = input.Split(' ');
                if (coords.Length != 2) continue;
                if (!int.TryParse(coords[0], out x)) continue;
                if (!int.TryParse(coords[1], out y)) continue;
                if (x < 0 || x > 9 || y < 0 || y > 9 || ConcreteTeam.GuessedAt(x, y))
                {
                    continue;
                }

                invalidInput = false;
            } while (invalidInput);
            return false;
        }
    }
}
