using System;

namespace Spite
{
    /// <summary>
    /// Provides methods useful in building a team.
    /// </summary>
    public class TeamBuilder
    {
        private ITeam builtTeam;

        /// <summary>
        /// Starts building the team with a fresh instance of the specified team type.
        /// </summary>
        /// <typeparam name="TTeam">The type of team to create.</typeparam>
        /// <returns>The team builder for chaining.</returns>
        public TeamBuilder Start<TTeam>() where TTeam : ITeam, new()
        {
            builtTeam = new TTeam();
            return this;
        }

        /// <summary>
        /// Sets the number of entity slots on this team.
        /// </summary>
        /// <param name="teamSize">The initial or max size of the team.</param>
        /// <param name="isSizeCapped">Whether or not the team can have more entities than the initial amount.</param>
        /// <returns>The team builder for chaining.</returns>
        public TeamBuilder SetTeamSize(uint teamSize, bool isSizeCapped)
        {
            builtTeam.InitializeEntityCount(teamSize, isSizeCapped);
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
        public TeamBuilder SetTeamStandingDeterminer(Func<Arena, TeamStanding> winConFunc)
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
        /// <typeparam name="TTeam">The team type to cast to. Should be the same type as used in TTeam.</typeparam>
        /// <returns>The team of the specified type.</returns>
        public TTeam Finish<TTeam>() where TTeam : ITeam
        {
            if (builtTeam == null)
            {
                throw new InvalidOperationException("Start has not been called - no team was being built.");
            }
            if (!(builtTeam is TTeam))
            {
                throw new InvalidCastException($"Can't cast the built team to {typeof(TTeam)}. Check the typeparam of Start and Finish.");
            }
            return (TTeam)builtTeam;
        }
    }
}
