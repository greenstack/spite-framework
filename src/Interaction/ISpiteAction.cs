namespace Spite.Interaction
{
    /// <summary>
    /// Represents an action that can be performed in the Spite context.
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

        /// <summary>
        /// Performs the action and gets the reaction.
        /// </summary>
        /// <typeparam name="T">The type of data expected for the reaction.</typeparam>
        /// <returns>The reaction to this action.</returns>
        IReaction<T> UseAndGetReaction<T>() where T : struct;
    }
}
