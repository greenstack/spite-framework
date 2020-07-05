using Spite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteRpg
{
    class CombatMenuController
    {

        private readonly CombatMenu menu;
        private readonly Arena<RpgTeam, RpgEntity> arena;
        private RpgTeam playerTeam;

        // TODO: Have this managed by the arena or the turn manager
        private int currentPhase = 0;

        private int selectedIndex = 0;

        public CombatMenuController(CombatMenu menu, Arena<RpgTeam, RpgEntity> arena)
        {
            this.menu = menu;
            this.arena = arena;
            playerTeam = arena.Teams[0];
        }

        public void ReadInput()
        {
            var input = Console.ReadKey(true);
            if (currentPhase != 2 && input.Key == ConsoleKey.Enter)
            {
                currentPhase++;
            }
            else if (input.Key == ConsoleKey.Enter)
            {
                currentPhase = 0;
            }
            else if (currentPhase != 0 && input.Key == ConsoleKey.Backspace)
            {
                currentPhase--;
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                selectedIndex += 2;
                selectedIndex %= 3;
                menu.actors[currentPhase] = (RpgEntity)playerTeam.Entities.ElementAt(selectedIndex);
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                selectedIndex++;
                selectedIndex %= 3;
                menu.actors[currentPhase] = (RpgEntity)playerTeam.Entities.ElementAt(selectedIndex);
            }
        }
    }
}
