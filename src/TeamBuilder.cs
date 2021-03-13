using System;

namespace Spite
{
    /// <summary>
    /// Provides methods useful in building a team.
    /// </summary>
    public class TeamBuilder<TTeam, TEntity> where TTeam : ITeam<TEntity>, new() where TEntity : ITeammate
    {
        private TTeam builtTeam;

        /// <summary>
        /// Starts building the team with a fresh instance of the specified team type.
        /// </summary>
        /// <typeparam name="TTeam">The type of team to create.</typeparam>
        /// <returns>The team builder for chaining.</returns>
        public TeamBuilder<TTeam, TEntity> Start()
        {
            builtTeam = new TTeam();
            return this;
        }

        /// <summary>
        /// Sets the number of entity slots on this team.
        /// </summary>
        /// <param name="teamSize">The initial or max size of the team.</param>
        /// <returns>The team builder for chaining.</returns>
        public TeamBuilder<TTeam, TEntity> SetTeamSize(uint teamSize)
        {
            builtTeam.InitializeEntityCount(teamSize);
            return this;
        }

        /// <summary>
        /// Adds the entity to the team.
        /// </summary>
        /// <param name="entity">The entity to add to the team.</param>
        /// <returns>The TeamBuilder for chaining.</returns>
        public TeamBuilder<TTeam, TEntity> AddEntity(TEntity entity)
        {
            builtTeam.AddEntity(entity);
            return this;
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
