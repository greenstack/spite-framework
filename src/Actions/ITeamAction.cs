namespace Spite.Actions
{
    /// <summary>
    /// An interface for actions that can be taken against teams.
    /// </summary>
    public interface ITeamAction<TTeam> : IAction where TTeam : ITeam
    {
        /// <summary>
        /// The Team targeted by this action.
        /// </summary>
        TTeam Target { get; }

        /// <summary>
        /// Accepts a ITeamActionVisitor object.
        /// </summary>
        /// <param name="visitor">The object visiting this action.</param>
        void Accept(ITeamActionVisitor visitor);
    }
}
