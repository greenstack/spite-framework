namespace Spite.Actions
{
    /// <summary>
    /// Represents an action that can be applied to an entity.
    /// </summary>
    public interface IEntityAction<TEntity> : IAction where TEntity : IEntity
    {
        /// <summary>
        /// The entity targeted by this action.
        /// </summary>
        TEntity Target { get; }
    }
}
