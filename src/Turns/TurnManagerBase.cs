using Spite.Interaction;
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
            set {
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

        /// <summary>
        /// If set to true, the <see cref="IReaction.FollowUpAction" /> property of
        /// any reaction received will be executed even if the base action failed.
        /// </summary>
        public readonly bool ExecuteFollowUpsIfActionFailed;

        /// <summary>
        /// Creates a basic TurnManager.
        /// </summary>
        /// <param name="executeFollowUpsIfActionFailed">If a reaction has a follow-up, should it be executed even if the action failed?</param>
        public TurnManagerBase(bool executeFollowUpsIfActionFailed)
        {
            ExecuteFollowUpsIfActionFailed = executeFollowUpsIfActionFailed;
        }

        /// <summary>
        /// Tries to execute the command.
        /// </summary>
        /// <returns>All of the reactions that arise as a result of the command or null if the command is invalid or cannot be executed.</returns>
        public IReaction[] AcceptCommand(CommandBase command)
        {
            List<IReaction> reactions = new List<IReaction>();
            if (CurrentPhase.IsCommandExecutableThisPhase(command) && command.IsValid()) {
                var result = command.Execute();
                reactions.Add(result);
                
                while (ShouldExecuteFollowUp(result))
                {
                    result = result.FollowUpAction.UseAndGetReaction();
                    reactions.Add(result);
                }

                return reactions.ToArray();
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Checks if the given actor can perform an action.
        /// </summary>
        /// <param name="actor">The actor that wants to act.</param>
        /// <returns>True if the actor can act right now; otherwise, false.</returns>
        public abstract bool CanAct(IActor actor);

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