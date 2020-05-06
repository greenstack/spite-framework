using System;
using System.Collections.Generic;
using System.Text;

namespace Spite
{
    /// <summary>
    /// 
    /// </summary>
    public class TeamBuilder
    {
        private ITeam builtTeam;

        /// <summary>
        /// Starts building the team with a fresh instance of the specified team type.
        /// </summary>
        /// <typeparam name="TTeam"></typeparam>
        /// <returns></returns>
        public TeamBuilder Start<TTeam>() where TTeam : ITeam, new()
        {
            builtTeam = new TTeam();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamSize"></param>
        /// <param name="isSizeCapped">Whether or not the team can have </param>
        /// <returns></returns>
        public TeamBuilder SetTeamSize(uint teamSize, bool isSizeCapped)
        {
            builtTeam.InitializeEntityCount(isSizeCapped, teamSize);
            return this;
        }

        /// <summary>
        /// Adds the entity to the team.
        /// </summary>
        /// <param name="entity">The entity to add to the team.</param>
        /// <returns>The TeamBuilder for chaining.</returns>
        public TeamBuilder AddEntity(IEntity entity)
        {
            builtTeam.AddEntity(entity);
            return this;
        }

        /// <summary>
        /// Sets the win condition for this team.
        /// </summary>
        /// <param name="winConFunc">The function that will be used to determine the win conditions.</param>
        /// <returns>The TeamBuilder for chaining.</returns>
        public TeamBuilder SetWinCondition(Func<Arena, bool> winConFunc)
        {
            return this;
        }

        /// <summary>
        /// Finishes building the team.
        /// </summary>
        /// <returns>The built team.</returns>
        public ITeam Finish()
        {
            return builtTeam;
        }

        /// <summary>
        /// Finsihes building the team and casts it to the specific type.
        /// </summary>
        /// <typeparam name="TTeam">The team type to cast to.</typeparam>
        /// <returns>The team of the specified type.</returns>
        public TTeam Finish<TTeam>() where TTeam : ITeam
        {
            return (TTeam)builtTeam;
        }
    }
}
