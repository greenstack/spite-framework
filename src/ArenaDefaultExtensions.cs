using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Spite
{
    /// <summary>
    /// Provides default implementations for Arenas. (I can't wait for C#8.0)
    /// </summary>
    public static class ArenaDefaultExtensions
    {
        /// <summary>
        /// Retrieves the teams that oppose the given team.
        /// </summary>
        /// <param name="arena">The arena being checked.</param>
        /// <param name="team">The team that should retrieve its enemies.</param>
        /// <returns>The teams opposing the provided team.</returns>
        public static IEnumerable<ITeam> GetTeamsOpposing(this IArena arena, ITeam team)
        {
            // Justification: it'll fail if the arena is null anyways.
#pragma warning disable CA1062 // Validate arguments of public methods
            return from side in arena.Sides
#pragma warning restore CA1062 // Validate arguments of public methods
                   where side != team
                   select side;
        }

        /// <summary>
        /// Updates all the team standings in the arena.
        /// </summary>
        /// <param name="arena">The arena being updated.</param>
        public static void UpdateTeamStandings(this IArena arena)
        {
            if (arena is null)
            {
                throw new ArgumentNullException(nameof(arena));
            }
            foreach (var s in arena.Sides)
            {
                s.DetermineStanding(arena);
            }
        }
    }
}
