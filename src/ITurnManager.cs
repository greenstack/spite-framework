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
        /// Determines if the turn controller can perform the given action.
        /// </summary>
        /// <param name="actor">The actor wanting to perform the action.</param>
        /// <param name="action">The action to be performed.</param>
        /// <returns>True if the actor can perform the action.</returns>
        bool CanControllerAct(ITurnController actor, IAction action);
    }
}
