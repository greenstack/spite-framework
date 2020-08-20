using Spite.Actions;
using System;

namespace Spite
{
    /// <summary>
    /// Manages the turns in an arena.
    /// </summary>
    public interface ITurnManager
    {
        /// <summary>
        /// The current team controller.
        /// </summary>
        [Obsolete("We're moving towards IActor instead. Furthermore, if Managers need to know who can currently act, specific implementations should do that.")]
        ITurnController CurrentController { get; }

        /// <summary>
        /// The current phase in the turn.
        /// </summary>
        ITurnPhase CurrentPhase { get; }

        /// <summary>
        /// Triggered when the Turn Manager's internal state (phase) changes.
        /// </summary>
        event ChangePhase OnPhaseChanged;

        /// <summary>
        /// Determines if the turn controller can perform the given action.
        /// </summary>
        /// <param name="actor">The actor wanting to perform the action.</param>
        /// <param name="action">The action to be performed.</param>
        /// <returns>True if the actor can perform the action.</returns>
        [Obsolete("Since we're moving to IActors, use ITurnManager.CanBeExecuted instead.")]
        bool CanControllerAct(ITurnController actor, IAction action);

        /// <summary>
        /// Has the current controller accept a turn.
        /// </summary>
        /// <param name="arena">The arena the turn takes place in.</param>
        /// <returns>Whether or not the battle should end.</returns>
        bool DoTurn(IArena arena);

        /// <summary>
        /// Determines if the given command can be executed. It may check the command's Executor, this TurnManager's internal state, and other items.
        /// </summary>
        /// <param name="command">The command to check.</param>
        /// <returns>True if the command can be executed by its owner, otherwise, false.</returns>
        bool CanBeExecuted(ICommand command);
    }
}
