using System;
using System.Collections.Generic;
using System.Text;

namespace Spite.Actions
{
    public interface IAction
    {
        /// <summary>
        /// The arena in which this action is being made.
        /// </summary>
        IArena Context { get; }

        /// <summary>
        /// Executes this action on the target.
        /// </summary>
        /// <param name="target">The targeted entity.</param>
        /// <returns>The results of the command.</returns>
        IActionResult Execute();
    }
}
