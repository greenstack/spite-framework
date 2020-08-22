using Spite;
using System;

namespace SpiteBattleship
{
    class PlayerBattleshipController : BattleshipActor
    {

        public override string Name => "player";

        private readonly BattleshipTeam opponent;

        public PlayerBattleshipController(BattleshipTeam playerTeam, BattleshipTeam opponent) : base (playerTeam)
        {
            this.opponent = opponent;
        }

        public bool askPlayerForInput(ref int x, ref int y)
        {
            bool invalidInput = true;
            do
            {
                Console.Clear();
                Console.Write(Team.ToString());
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
                if (x < 0 || x > 9 || y < 0 || y > 9 || Team.DidGuessAt(x, y))
                {
                    continue;
                }

                invalidInput = false;
            } while (invalidInput);
            return false;
        }

        public override BattleshipCommand GetAction(BattleshipTurnManager turnManager)
        {
            string input = Console.ReadLine();
            // TODO: Input validation
            if (input.ToLower() == "q")
            {
                Team.ForceStanding(TeamStanding.Defeated);
                return new ForfeitCommand(turnManager, this);
            }

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

            return new GuessCommand(turnManager, this, opponent, x, y);
        }
    }
}
