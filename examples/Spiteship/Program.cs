﻿using Spite;
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

            arena = new ArenaBuilder()
                .InitArena("battleship", 2)
                .SetTurnScheme(TurnScheme.Team)
                .AddTeam(player)
                .AddTeam(AI)
                .Finish();

            // While no team has won, play the game.
            int x = 0, y = 0;
            bool quit = false;
            // We're using this action visitor to showcase why it may be useful
            // to have the action visitor. In a full game, you may want to use
            // this supplied visitor pattern to handle animations and such, as
            // well as logging messages to the screen for the player to see.
            // BattleshipActionAnimator, BattleshipActionLogger are possible
            // examples here that could work.
            BattleshipActionPrinter printer = new BattleshipActionPrinter();
            do
            {
                quit = playerContoller.askPlayerForInput(ref x, ref y);
                var ga = new GuessAction(AI, arena, x, y);
                if (quit) break;
                printer.Visit(ga);
                // Let the user see the output of the visitor.
                Thread.Sleep(1000);
                var result = ga.Execute();
                player.InformGuessStatus(result as GuessActionResult);
                arena.UpdateTeamStandings();
            } while (!arena.AnyTeamHasStanding(TeamStanding.Eliminated));
        }

        /// <summary>
        /// Builds a simple side for battleship.
        /// </summary>
        /// <returns></returns>
        static BattleshipTeam BuildTeam()
        {
            TeamBuilder builder = new TeamBuilder();
            return builder.Start<BattleshipTeam>()
                .SetTeamSize(SHIPS_PER_SIDE)
                .AddEntity(new ShipEntity("Carrier", 5))
                .AddEntity(new ShipEntity("Battleship", 4))
                .AddEntity(new ShipEntity("Destroyer", 3))
                .AddEntity(new ShipEntity("Submarine", 3))
                .AddEntity(new ShipEntity("Patrol Boat", 2))
                .Finish<BattleshipTeam>();
        }
    }
}
