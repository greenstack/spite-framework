using System;

namespace Spite.Actions
{
    /// <summary>
    /// Represents an action that can be applied to an entity.
    /// </summary>
    [Obsolete]
    public interface IEntityAction<TEntity> : IAction where TEntity : IEntity
    {
        /// <summary>
        /// The entity targeted by this action.
        /// </summary>
        TEntity Target { get; }

        /// <summary>
        /// Accepts a ITeamActionVisitor object.
        /// </summary>
        /// <param name="visitor">The object visiting this action.</param>
        void Accept(IEntityActionVisitor visitor);
    }
}
