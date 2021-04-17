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
                Console.WriteLine("Enter a coordinate to launch an attack at. Q to quit. (Currently the only supported item)");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    return new ForfeitCommand(this);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
