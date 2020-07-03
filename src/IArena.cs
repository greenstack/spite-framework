using System.Collections.Generic;

namespace Spite
{
    /// <summary>
    /// Manages a group of sides in a battle.
    /// </summary>
    public interface IArena
    {
        /// <summary>
        /// All the teams that are fighting in this arena.
        /// </summary>
        IList<ITeam> Teams { get; }

        /// <summary>
        /// The number of teams managed by this arena.
        /// </summary>
        int TeamCount { get; }

        /// <summary>
        /// The name of this arena.
        /// </summary>
        string ArenaName { get; }

        /// <summary>
        /// This Arena's TurnManager.
        /// </summary>
        ITurnManager TurnManager { get; }
    }
}
