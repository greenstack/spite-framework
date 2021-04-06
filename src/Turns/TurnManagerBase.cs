using Spite.Interaction;
using System.Collections.Generic;

namespace Spite.Turns
{
    /// <summary>
    /// Provides the basic functionality for turn management.
    /// </summary>
    public abstract class TurnManagerBase : ITurnManager
    {
        public ITurnPhase CurrentPhase => throw new System.NotImplementedException();

        public event ChangePhase OnPhaseChanged;

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

        public bool CanAct(IActor actor)
        {
            throw new System.NotImplementedException();
        }

        [System.Obsolete("Use CAR model instead")]
        public bool CanBeExecuted<TContext>(ICommand<TContext> command)
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        private bool ShouldExecuteFollowUp(IReaction result)
        {
            return result.FollowUpAction != null &&
                    (
                        !result.ActionSuccessful ||
                        ExecuteFollowUpsIfActionFailed
                    );
        }
    }
}