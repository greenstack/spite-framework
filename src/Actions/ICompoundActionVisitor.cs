using System;

namespace Spite.Actions
{
    /// <summary>
    /// An interface that extends both ITeamActionVisitor and IEntityActionVisitor.
    /// See <see cref="ITeamActionVisitor"/> and <see cref="IEntityActionVisitor"/>.
    /// </summary>
    [Obsolete]
    public interface ICompoundActionVisitor : 
        ITeamActionVisitor, 
        IEntityActionVisitor
    { }
}
