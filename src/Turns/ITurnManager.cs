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
        /// The method used to determine if a battle has been completed.
        /// 
        /// TODO: Once we can support C# 8 (Unity 2021.2, change this to 
        /// "internal set" (conditions probably shouldn'tchange in the middle
        /// of a battle).
        /// </summary>
        System.Func<bool> IsBattleOver { get; set; }

        /// <summary>
        /// Triggered when the Turn Manager's internal state (phase) changes.
        /// </summary>
        event ChangePhase OnPhaseChanged;

        /// <summary>
        /// Tries to execute the command.
        /// </summary>
        /// <returns>All of the reactions that arise as a result of the command or null if the command is invalid or cannot be executed.</returns>
        IReaction[] AcceptCommand(CommandBase command, IArena context);
    }
}
