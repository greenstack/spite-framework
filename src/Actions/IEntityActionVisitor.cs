using System;

namespace Spite.Actions
{
    /// <summary>
    /// Provides an interface for IEntityActionVisitors.
    /// </summary>
    [Obsolete]
    public interface IEntityActionVisitor
    {
        /// <summary>
        /// Visits an entityAction.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity the action acts upon.</typeparam>
        /// <param name="entityAction">The action being visited.</param>
        void Visit<TEntity>(IEntityAction<TEntity> entityAction) where TEntity : IEntity;
    }
}
