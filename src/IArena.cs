using System.Collections.Generic;

namespace Spite
{
    /// <summary>
    /// Manages a group of sides in a battle.
    /// </summary>
    public interface IArena
    {
        /// <summary>
        /// All the teams/sides that are fighting in this arena.
        /// </summary>
        IList<ITeam> Sides { get; }

        /// <summary>
        /// The number of sides managed by this arena.
        /// </summary>
        int SideCount { get; }

        /// <summary>
        /// The name of this arena.
        /// </summary>
        string ArenaName { get; }
    }
}
