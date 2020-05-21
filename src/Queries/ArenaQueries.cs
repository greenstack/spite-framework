using System.Collections.Generic;
using System.Linq;

namespace Spite.Queries
{
    /// <summary>
    /// Provides some queries that can be used with Arenas.
    /// </summary>
    public static class ArenaQueries
    {
        /// <summary>
        /// Determines if any team in the arena has the current standing.
        /// </summary>
        /// <param name="arena">The arena to check.</param>
        /// <param name="standing">The standing to check for.</param>
        /// <returns>True if any team has the given standing.</returns>
        public static bool AnyTeamHasStanding(this IArena arena, TeamStanding standing)
        {
            return arena.Sides.Any((team) => team.CurrentStanding == standing);
        }

        /// <summary>
        /// Gets the number of teams with the given standing.
        /// </summary>
        /// <param name="arena">The arena to check against.</param>
        /// <param name="standing">The standing to search for.</param>
        /// <returns>The number of teams with the given standing.</returns>
        public static int CountTeamsWithStanding(this IArena arena, TeamStanding standing)
        {
            return arena.GetTeamsWithStanding(standing).Count();
        }

        /// <summary>
        /// Gets all the teams with the given standing.
        /// </summary>
        /// <param name="arena">The arena to check against.</param>
        /// <param name="standing">The standing to search for.</param>
        /// <returns>A sequence of teams that match the check.</returns>
        public static IEnumerable<ITeam> GetTeamsWithStanding(this IArena arena, TeamStanding standing)
        {
            return from team in arena.Sides
                   where team.CurrentStanding == standing
                   select team;
        }
    }
}
