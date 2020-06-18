using Spite.Actions;
using System;
using System.Collections.Generic;

namespace Spite
{
    /// <summary>
    /// Manages a group of sides in a battle.
    /// </summary>
    public class Arena : IArena
    {
        /// <summary>
        /// All the teams/sides that are fighting in this arena.
        /// </summary>
        readonly internal ITeam[] sides;

        /// <inheritdoc/>
        public IList<ITeam> Sides => sides;

        /// <summary>
        /// Gets the turn manager.
        /// </summary>
        public ITurnManager TurnManager { get; }

        /// <summary>
        /// The controller that is currently acting.
        /// </summary>
        public ITurnController CurrentController { get => TurnManager.CurrentController; }

        /// <summary>
        /// The number of sides managed by this arena.
        /// </summary>
        public int SideCount => sides.Length;

        /// <summary>
        /// The name of this arena.
        /// </summary>
        public string ArenaName { get; }

        /// <summary>
        /// Creates an arena with the specified number of sides fighting in it.
        /// </summary>
        /// <param name="numberOfSides">The number of sides fighting in the arena.</param>
        /// <param name="turnManager">The object that manages the turns in this arena.</param>
        public Arena(uint numberOfSides, ITurnManager turnManager)
        {
            sides = new ITeam[numberOfSides];
            TurnManager = turnManager;
        }

        /// <summary>
        /// Creates a named arena with the specified number of sides fighting in it.
        /// </summary>
        /// <param name="name">The name of the arena.</param>
        /// <param name="numberOfSides">The number of sides fighting in the arena.</param>
        /// <param name="turnManager">The object that manages the turns in this arena.</param>
        public Arena(string name, uint numberOfSides, ITurnManager turnManager)
        {
            ArenaName = name;
            sides = new ITeam[numberOfSides];
            TurnManager = turnManager;
        }

        /// <summary>
        /// Gets the team with the given index.
        /// </summary>
        /// <param name="index">The index of the team.</param>
        /// <returns>The team at the specified index</returns>
        public ITeam GetTeam(uint index)
        {
            return sides[index];
        }

        /// <summary>
        /// Tries to perform an action within the arena.
        /// </summary>
        /// <param name="actor">The actor performing the action.</param>
        /// <param name="action">The action that wants to be performed.</param>
        /// <returns>The result of the action or an <see cref="ActionFailedResult"/> if the actor could not act.</returns>
        public IActionResult PerformAction(ITurnController actor, IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (TurnManager.CanControllerAct(actor, action))
            {
                return action.Execute();
            }
            return new ActionFailedResult();
        }

        // TODO: Do we need a BeginBattle function?

        public void DoBattle()
        {
            do
            {
                TurnManager.DoTurn(this);
            } while (true);
        }
    }
}
