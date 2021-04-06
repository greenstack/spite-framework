using Spite.Interaction;

namespace Spite.Turns
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
        [System.Obsolete("Why is this needed? Turn phases and states can manage this instead.")]
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
        [System.Obsolete("Use AcceptCommand with the CAR model instead.")]
        bool CanBeExecuted<TContext>(ICommand<TContext> command);

        /// <summary>
        /// Tries to execute the command.
        /// </summary>
        /// <returns>All of the reactions that arise as a result of the command or null if the command is invalid or cannot be executed.</returns>
        IReaction[] AcceptCommand(CommandBase command);
    }
}
