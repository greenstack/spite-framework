namespace Spite
{
    /// <summary>
    /// Manages a group of sides in a battle.
    /// </summary>
    public class Arena
    {
        /// <summary>
        /// All the teams/sides that are fighting in this arena.
        /// </summary>
        readonly internal ITeam[] Sides;

        /// <summary>
        /// The number of sides managed by this arena.
        /// </summary>
        public int SideCount => Sides.Length;

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
            Sides = new ITeam[numberOfSides];
        }

        /// <summary>
        /// Creates a named arena with the specified number of sides fighting in it.
        /// </summary>
        /// <param name="name">The name of the arena.</param>
        /// <param name="numberOfSides">The number of sides fighting in the arena.</param>
        public Arena(string name, uint numberOfSides)
        {
            ArenaName = name;
            Sides = new ITeam[numberOfSides];
        }

        /// <summary>
        /// Gets the team with the given index.
        /// </summary>
        /// <param name="index">The index of the team.</param>
        /// <returns>The team at the specified index</returns>
        public ITeam GetTeam(uint index)
        {
            return Sides[index];
        }

    }
}
