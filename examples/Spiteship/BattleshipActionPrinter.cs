using Spite.Actions;
using System;
using System.Threading;

namespace SpiteBattleship
{
    class BattleshipActionPrinter : ITeamActionVisitor
    {
        /// <summary>
        /// Delegates to a specific visit type.
        /// </summary>
        /// <typeparam name="BattleshipTeam">A Battleship Team.</typeparam>
        /// <param name="teamAction">The team action being taken.</param>
        void ITeamActionVisitor.Visit<BattleshipTeam>(ITeamAction<BattleshipTeam> teamAction)
        {
            switch (teamAction)
            {
                case GuessAction guess:
                    Visit(guess);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Visit(GuessAction action)
        {
            Console.WriteLine($"Attacking {action.x}, {action.y}");
            Thread.Sleep(500);
        }
    }
}
