namespace Spite.Interaction
{
    /// <summary>
    /// Represents the information regarding the result of an action.
    /// </summary>
    public interface IReaction
    {
        /// <summary>
        /// The action that created this reaction.
        /// 
        /// NOTE: When we get C# 9 support available in Unity 2021.2, this set
        /// property will be changed to an init property.
        /// </summary>
        ISpiteAction CausingAction { get; set; }

        /// <summary>
        /// If this reaction causes another action to occur, this should be set.
        /// 
        /// Otherwise, it should be null.
        /// </summary>
        ISpiteAction FollowUpAction { get; }

        /// <summary>
        /// Did the action succeed?
        /// </summary>
        bool ActionSuccessful { get; }

        /// <summary>
        /// Gets the reaction's data as a generic object.
        /// </summary>
        /// <returns>The object's reaction data.</returns>
        object GetReactionData();

        /// <summary>
        /// Gets the reaction's data cast to the specified type.
        /// </summary>
        /// <typeparam name="TReactionData">The type of data the reaction contains.</typeparam>
        /// <returns>The reaction's data. Should be the same as GetReactionData.</returns>
        TReactionData GetReactionData<TReactionData>();
    }

    /// <summary>
    /// Provides an interface for templated reaction data objects.
    /// </summary>
    /// <typeparam name="TReactionData">The resulting data's type.</typeparam>
    public interface IReaction<TReactionData> : IReaction {
        /// <summary>
        /// The data held by this reaction.
        /// </summary>
        TReactionData ReactionData { get; }
    }
}
