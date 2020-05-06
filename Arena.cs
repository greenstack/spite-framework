namespace Spite
{
    /// <summary>
    /// Manages a group of sides in a battle.
    /// </summary>
    public class Arena
    {
        /// <summary>
        /// 
        /// </summary>
        readonly internal ITeam[] Sides;

        /// <summary>
        /// The number of sides managed by this arena.
        /// </summary>
        public int SideCount => Sides.Length;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfSides"></param>
        public Arena(uint numberOfSides)
        {
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
