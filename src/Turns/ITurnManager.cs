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
        /// Tries to execute the command.
        /// </summary>
        /// <returns>All of the reactions that arise as a result of the command or null if the command is invalid or cannot be executed.</returns>
        IReaction[] AcceptCommand(CommandBase command);
    }
}
