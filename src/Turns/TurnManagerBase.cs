using Spite.Interaction;
using System;
using System.Collections.Generic;

namespace Spite.Turns
{
    /// <summary>
    /// Provides the basic functionality for turn management.
    /// </summary>
    public abstract class TurnManagerBase : ITurnManager
    {
        private ITurnPhase currentPhase;

        /// <summary>
        /// The current phase in the turn.
        /// </summary>
        public virtual ITurnPhase CurrentPhase {
            get => currentPhase;
            private set {
                if (value != currentPhase) {
                    OnPhaseChanged?.Invoke(currentPhase, value, this);
                    currentPhase = value;
                }
            }
        }

        /// <summary>
        /// Invoked when the turn manager's current phase is changed.
        /// </summary>
        public event ChangePhase OnPhaseChanged;
        /// <inheritdoc/>
        public event TurnIncremented OnTurnIncremented;

		/// <summary>
		/// If set to true, the <see cref="IReaction.FollowUpAction"/> property of
		/// any reaction received will be executed even if the base action failed.
		/// </summary>
		public bool ExecuteFollowUpsIfActionFailed { get; }

        /// <inheritdoc/>
		public Func<bool> IsBattleOver { get; set; }

        private int turnNumber;

        /// <inheritdoc/>
		public int TurnNumber 
        { 
            get => turnNumber;
            protected set
			{
                int oldNumber = turnNumber;
                turnNumber = value;
                // Only fire the event if the new turn number is indeed greater than the old value.
                if (oldNumber < turnNumber)
                    OnTurnIncremented?.Invoke(this, value);
			}
        }

		/// <summary>
		/// Creates a basic TurnManager.
		/// </summary>
		/// <param name="initialPhase">The starting phase.</param>
		/// <param name="executeFollowUpsIfActionFailed">If a reaction has a follow-up, should it be executed even if the action failed?</param>
		public TurnManagerBase(ITurnPhase initialPhase, bool executeFollowUpsIfActionFailed)
        {
            currentPhase = initialPhase;
            ExecuteFollowUpsIfActionFailed = executeFollowUpsIfActionFailed;
        }

        /// <summary>
        /// Tries to execute the command.
        /// </summary>
        /// <returns>All of the reactions that arise as a result of the command or null if the command is invalid or cannot be executed.</returns>
        public IReaction[] AcceptCommand(CommandBase command, IArena context)
        {
            // Validate arguments
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            List<IReaction> reactions = new List<IReaction>();
            if (CurrentPhase.IsCommandExecutableThisPhase(command) && command.IsValid()) {
                var result = command.Execute();
                reactions.Add(result);
                
                while (ShouldExecuteFollowUp(result))
                {
                    result = result.FollowUpAction.UseAndGetReaction();
                    reactions.Add(result);
                }

                IReaction[] finalResult = reactions.ToArray();

                // Have the Arena update team standings here?
                // The issue is, as soon as a battle-over condition
                // has been met, we should jump on that.
                context.UpdateTeamStandings();
                if (IsBattleOver())
                    CurrentPhase = new BattleEndedPhase();
                else if (CurrentPhase.ShouldAdvancePhase(finalResult))
                    CurrentPhase = GetNextPhase();

                return finalResult;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the next phase based on the current phase (default behavior).
        /// </summary>
        /// <returns>The next phase.</returns>
        protected virtual ITurnPhase GetNextPhase()
		{
            if (IsBattleOver())
                return new BattleEndedPhase();
            return CurrentPhase.GetNextPhase();
		}

        /// <summary>
        /// Checks if the given command can be executed.
        /// </summary>
        /// <param name="command">TRUE if this command can be executed.</param>
        /// <returns>TRUE if the command can currently be executed.</returns>
        public virtual bool IsCommandExecutable(CommandBase command)
        {
            return CurrentPhase.IsCommandExecutableThisPhase(command);
        }
        
        /// <summary>
        /// DEPRECATED. Should be allowed to do things.
        /// </summary>
        [System.Obsolete("This can (and should) be done through the CAR model.")]
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Checks if a follow-up action provided by a result should be executed.
        /// </summary>
        /// <param name="result">The resulting attack.</param>
        /// <returns>True if the action stored in <see cref="IReaction.FollowUpAction" /> should be executed.</returns>
        private bool ShouldExecuteFollowUp(IReaction result)
        {
            return result.FollowUpAction != null &&
                    !result.ActionSuccessful &&
                    ExecuteFollowUpsIfActionFailed;
        }
    }
}