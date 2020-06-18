using Spite.Actions;

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
        bool CanControllerAct(ITurnController actor, IAction action);

        /// <summary>
        /// Has the current controller accept a turn.
        /// </summary>
        void DoTurn(IArena arena);
    }
}
