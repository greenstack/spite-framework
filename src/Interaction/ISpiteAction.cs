namespace Spite.Interaction
{
    /// <summary>
    /// The basic interface for ISpiteActions.
    /// </summary>
    public interface ISpiteAction
    {
        /// <summary>
        /// The teammate using this action.
        /// </summary>
        ITeammate User { get; }

        /// <summary>
        /// Is this action valid?
        /// </summary>
        /// <returns>True if the action is valid and can be executed.</returns>
        bool IsValid();

        IReaction UseAndGetReaction();
    }
}
