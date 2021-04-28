using System;
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
            if (arena is null)
            {
                throw new ArgumentNullException(nameof(arena));
            }
            return arena.Teams.Any((team) => team.CurrentStanding == standing);
        }

        /// <summary>
        /// Gets the number of teams with the given standing.
        /// </summary>
        /// <param name="arena">The arena to check against.</param>
        /// <param name="standing">The standing to search for.</param>
        /// <returns>The number of teams with the given standing.</returns>
        public static int CountTeamsWithStanding(this IArena arena, TeamStanding standing)
        {
            return arena.GetTeamsWithStanding<ITeam>(standing).Count();
        }

        /// <summary>
        /// Gets all the teams with the given standing.
        /// </summary>
        /// <param name="arena">The arena to check against.</param>
        /// <param name="standing">The standing to search for.</param>
        /// <returns>A sequence of teams that match the check.</returns>
        public static IEnumerable<T> GetTeamsWithStanding<T>(this IArena arena, TeamStanding standing) where T : ITeam
        {
            if (arena is null)
            {
                throw new ArgumentNullException(nameof(arena));
            }
            return from team in arena.Teams
                   where team.CurrentStanding == standing
                   select (T)team;
        }

        /// <summary>
        /// Gets a single opposing team from the arena.
        /// </summary>
        /// <typeparam name="TTeam">The type of team to cast to.</typeparam>
        /// <param name="arena">The arena to search in.</param>
        /// <param name="team">The team whose opponent you want to get.</param>
        /// <returns>The team that rivals the given team.</returns>
        /// <exception cref="ArgumentNullException">If either arena or team are null.</exception>
        /// <exception cref="InvalidOperationException">If there are multiple opposing teams.</exception>
        public static TTeam GetOpposingTeam<TTeam>(this IArena arena, TTeam team) where TTeam : ITeam
        {
            if (arena == null)
            {
                throw new ArgumentNullException(nameof(arena));
            }
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }
            return (TTeam)arena.Teams.Single(t => !((TTeam)t).Equals(team));
        }
    }
}
