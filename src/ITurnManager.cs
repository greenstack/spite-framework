namespace Spite
{
    /// <summary>
    /// Manages the turns in an arena.
    /// </summary>
    public interface ITurnManager
    {
        /// <summary>
        /// The current phase in the turn.
        /// </summary>
        ITurnPhase CurrentPhase { get; }

        /// <summary>
        /// Triggered when the Turn Manager's internal state (phase) changes.
        /// </summary>
        event ChangePhase OnPhaseChanged;

        /// <summary>
        /// Should be called once the battle starts.
        /// </summary>
        void Start();

        /// <summary>
        /// Determines if the provided actor is allowed to submit a command, has priority, or otherwise.
        /// </summary>
        /// <param name="actor">The actor to query for.</param>
        /// <returns>True if the given actor is allowed to act.</returns>
        bool CanAct(IActor actor);

        /// <summary>
        /// Determines if the given command can be executed. It may check the command's Executor, this TurnManager's internal state, and other items.
        /// </summary>
        /// <param name="command">The command to check.</param>
        /// <returns>True if the command can be executed by its owner, otherwise, false.</returns>
        bool CanBeExecuted(ICommand command);
    }
}
