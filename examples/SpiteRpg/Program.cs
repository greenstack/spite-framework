using Spite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteRpg
{
    /// <summary>
    /// SpiteRPG is a small text-based RPG that's designed to show how to use
    /// the Spite Framework in a less discrete way - that is, the flow of
    /// battle cannot be passed directly into the arena itself (see Spite
    /// Battleship for an example of this). Instead, commands must be
    /// constructed in an external loop and then moved around. Instead of all
    /// the context and data being inside the battle itself, controllers
    /// outside of the battle must do it instead.
    /// </summary>
    class Program
    {
        const int TEAM_COUNT = 2;

        static ITurnManager rpgTurnManager;

        static void Main()
        {
            //TeamBuilder<RpgTeam> playerTB = new TeamBuilder<RpgTeam>();
            //playerTB.Start()
            //    .Finish();
        }

        static Arena buildArena(ITeam playerTeam, ITeam aiTeam)
        {
            ArenaBuilder ab = new ArenaBuilder();
            ab.SetTurnManager(rpgTurnManager);
            ab.SetTeamCount(TEAM_COUNT);
            ab.AddTeam(playerTeam);
            ab.AddTeam(aiTeam);
            return ab.Finish();
        }
    }
}
