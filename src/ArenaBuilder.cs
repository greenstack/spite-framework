using Spite.Properties;
using System;

namespace Spite
{
    /// <summary>
    /// Provides methods useful for building and populating an arena.
    /// </summary>
    public class ArenaBuilder
    {
        private Arena builtArena;

        private int teamsAdded = 0;

        private TurnScheme? turnScheme = null;

        /// <summary>
        /// Creates an instance of an Arena Builder.
        /// </summary>
        public ArenaBuilder()
        {
        }

        /// <summary>
        /// Sets the number of sides fighting in the arena. Must be the first
        /// method called.
        /// </summary>
        /// <param name="sideCount">The number of sides fighting in this arena.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="Arena(uint)"/>
        /// <seealso cref="InitArena(string, uint)"/>
        public ArenaBuilder InitArena(uint sideCount)
        {
            builtArena = new Arena(sideCount);
            return this;
        }

        /// <summary>
        /// Sets the name of and number of sides fighting in the arena. Must be
        /// the first method called.
        /// </summary>
        /// <param name="arenaName">The name of the arena.</param>
        /// <param name="sideCount">The number of sides fighting in this arena.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="Arena(string, uint)"/>
        /// <seealso cref="InitArena(uint)"/>
        public ArenaBuilder InitArena(string arenaName, uint sideCount)
        {
            builtArena = new Arena(arenaName, sideCount);
            return this;
        }

        /// <summary>
        /// Sets the type of turn scheme that this arena will have.
        /// </summary>
        /// <param name="scheme">The scheme for determining the granularity and order of turns.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder SetTurnScheme(TurnScheme scheme)
        {
            turnScheme = scheme;
            return this;
        }

        /// <summary>
        /// Adds a team to this arena.
        /// </summary>
        /// <param name="team">The team to add to the arena.</param>
        /// <returns>The team to add to the arena.</returns>
        public ArenaBuilder AddTeam(ITeam team)
        {
            AssertArenaWasMade();
            builtArena.Sides[teamsAdded++] = team;
            return this;
        }

        /// <summary>
        /// Finishes building the Arena and returns the built arena.
        /// </summary>
        /// <returns>The built arena.</returns>
        public Arena Finish()
        {
            AssertArenaWasMade();
            return builtArena;
        }

        private void AssertArenaWasMade()
        {
            if (builtArena == null)
                throw new InvalidOperationException(Resources.ArenaNotStarted);
        }

        private void AssertValidTurnScheme(TurnScheme expected, bool checkForNull)
        {
            if (turnScheme != null && checkForNull && 
                (turnScheme & TurnScheme.Entity) == expected)
                throw new InvalidOperationException(Resources.InvalidTurnScheme);
        }
    }
}
