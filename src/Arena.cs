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
        /// The team that has the current turn.
        /// </summary>
        public ITurnController CurrentController { get; protected set; }

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
        public Arena(uint numberOfSides)
        {
            sides = new ITeam[numberOfSides];
        }

        /// <summary>
        /// Creates a named arena with the specified number of sides fighting in it.
        /// </summary>
        /// <param name="name">The name of the arena.</param>
        /// <param name="numberOfSides">The number of sides fighting in the arena.</param>
        public Arena(string name, uint numberOfSides)
        {
            ArenaName = name;
            sides = new ITeam[numberOfSides];
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
    }
}
