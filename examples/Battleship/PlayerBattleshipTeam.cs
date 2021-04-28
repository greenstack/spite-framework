using Spite.Interaction;
using System;

namespace Battleship
{
    class PlayerBattleshipTeam : BattleshipTeam
    {
        public override CommandBase GetCommand()
        {
            while(true)
            {
                Console.WriteLine("Your board:");
                Console.WriteLine(Board.ToString(this));
                Console.WriteLine("Enemy board:");
                Console.WriteLine(Opponent.Board.ToString(this));
                Console.WriteLine("Enter a coordinate (in the format \"x,y\") to launch an attack at. Q to quit. (Currently the only supported item)");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return new ForfeitCommand(this);
                }
                else if (input.Contains(','))
				{
                    string[] coords = input.Split(',');
                    if (coords.Length == 2)
					{
                        if (int.TryParse(coords[0], out int x) && int.TryParse(coords[1], out int y))
						{
                            return new GuessCommand(this, Opponent, x, y);
						}
					}
				}
                Console.WriteLine("Invalid input");
            }
        }

		public override string ToString()
		{
			return "You";
		}
	}
}
