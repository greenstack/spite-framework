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
    }
}
