using System;
using System.Collections.Generic;

namespace Spite.Actions
{
    /// <summary>
    /// Builds up an action that can be executed.
    /// </summary>
    public class ActionBuilder
    {
        readonly List<IAction> actions;

        /// <summary>
        /// Creates a new instance of the ActionBuilder.
        /// </summary>
        public ActionBuilder()
        {
            actions = new List<IAction>();
        }

        /// <summary>
        /// Adds an action that applies to an entire team.
        /// </summary>
        /// <typeparam name="TTeam">The type of team this applies to.</typeparam>
        /// <param name="action">The action that will be executed.</param>
        /// <returns>The action builder for chaining.</returns>
        public ActionBuilder AddAction<TTeam>(ITeamAction<TTeam> action) where TTeam : ITeam
        {
            actions.Add(action);
            return this;
        }

        /// <summary>
        /// Adds an action that applies to an entity.
        /// </summary>
        /// <typeparam name="TEntity">The entity type this action applies to.</typeparam>
        /// <param name="action">The action to be executed.</param>
        /// <returns>The action builder for chaining.</returns>
        public ActionBuilder AddAction<TEntity>(IEntityAction<TEntity> action) where TEntity : IEntity
        {
            actions.Add(action);
            return this;
        }

        /// <summary>
        /// Retrieves all the commands that have been added.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IAction> GetActions()
        {
            return actions;
        }
    }
}
