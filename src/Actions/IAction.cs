using System;

namespace Spite.Actions
{
    /// <summary>
    /// Provides an interface for actions that can be used during battle.
    /// </summary>
    [Obsolete]
    public interface IAction
    {
        /// <summary>
        /// The arena in which this action is being made.
        /// </summary>
        IArena Context { get; }

        /// <summary>
        /// The result of the action after being executed.
        /// </summary>
        IActionResult Result { get; }

        /// <summary>
        /// Executes this action on the target.
        /// </summary>
        /// <returns>The results of the command.</returns>
        IActionResult Execute();
    }
}
