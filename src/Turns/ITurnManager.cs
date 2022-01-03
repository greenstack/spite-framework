﻿using Spite.Interaction;

namespace Spite.Turns
{
    /// <summary>
    /// Represents when the turn manager's turn number is incremented.
    /// </summary>
    /// <param name="sender">The turn manager that's been updated.</param>
    /// <param name="turnNumber">The new turn number.</param>
    public delegate void TurnIncremented(ITurnManager sender, int turnNumber);
    
    /// <summary>
    /// Manages the turns in an arena.
    /// </summary>
    public interface ITurnManager
    {

        /// <summary>
        /// Triggered when the turn is incremented.
        /// </summary>
        event TurnIncremented OnTurnIncremented;

        /// <summary>
        /// Provides the current turn number.
        /// </summary>
        int TurnNumber { get; }

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
