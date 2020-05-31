namespace Spite.Actions
{
    /// <summary>
    /// Provides an interface for IActionVisitor objects.
    /// </summary>
    public interface ITeamActionVisitor
    {
        /// <summary>
        /// Visits a teamAction.
        /// </summary>
        /// <typeparam name="TTeam">The type of team the action is impacted.</typeparam>
        /// <param name="teamAction">The action being visited.</param>
        void Visit<TTeam>(ITeamAction<TTeam> teamAction) where TTeam : ITeam;
    }
}
