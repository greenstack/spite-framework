using System;
using System.Linq;

namespace Spite.Queries
{
    /// <summary>
    /// Provides various methods to query teams with.
    /// </summary>
    public static class TeamQueryExtensions
    {
        /// <summary>
        /// Counts the number of entities still alive on the team.
        /// </summary>
        /// <param name="team">The team to query.</param>
        /// <returns>The number of living entities.</returns>
        public static int CountLivingEntities<T>(this ITeam<T> team) where T : IEntity
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            return team.Entities.Count(e => e.IsAlive);
        }

        public static bool AreAnyEntitiesAlive<T>(this ITeam<T> team) where T : IEntity
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            return team.Entities.Any(e => e.IsAlive);
        }

        /// <summary>
        /// Determines if all entities are alive on the team.
        /// </summary>
        /// <param name="team">The team to query.</param>
        /// <returns>True if all entities on this team are alive.</returns>
        public static bool AreAllEntitiesAlive<T>(this ITeam<T> team) where T : IEntity
        {
            if (team == null) throw new ArgumentNullException(nameof(team));
            return team.CountLivingEntities() == team.ManagedEntityCount;
        }
    }
}
