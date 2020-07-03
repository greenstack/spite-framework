using System;

namespace Spite
{
    /// <summary>
    /// Provides methods useful in building a team.
    /// </summary>
    public class TeamBuilder<TTeam> where TTeam : ITeam, new()
    {
        private TTeam builtTeam;

        /// <summary>
        /// Starts building the team with a fresh instance of the specified team type.
        /// </summary>
        /// <typeparam name="TTeam">The type of team to create.</typeparam>
        /// <returns>The team builder for chaining.</returns>
        public TeamBuilder<TTeam> Start()
        {
            builtTeam = new TTeam();
            return this;
        }

        /// <summary>
        /// Sets the number of entity slots on this team.
        /// </summary>
        /// <param name="teamSize">The initial or max size of the team.</param>
        /// <returns>The team builder for chaining.</returns>
        public TeamBuilder<TTeam> SetTeamSize(uint teamSize)
        {
            builtTeam.InitializeEntityCount(teamSize);
            return this;
        }

        /// <summary>
        /// Adds the entity to the team.
        /// </summary>
        /// <param name="entity">The entity to add to the team.</param>
        /// <returns>The TeamBuilder for chaining.</returns>
        public TeamBuilder<TTeam> AddEntity(IEntity entity)
        {
            builtTeam.AddEntity(entity);
            return this;
        }

        /// <summary>
        /// Sets the win condition for this team.
        /// </summary>
        /// <param name="winConFunc">The function that will be used to determine the win conditions.</param>
        /// <returns>The TeamBuilder for chaining.</returns>
        public TeamBuilder<TTeam> SetTeamStandingDeterminer(Func<Arena, TeamStanding> winConFunc)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Finishes building the team.
        /// </summary>
        /// <returns>The built team.</returns>
        public TTeam Finish()
        {
            return builtTeam;
        }
    }
}
