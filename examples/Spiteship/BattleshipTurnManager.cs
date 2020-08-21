using Spite;
using Spite.Actions;
using Spite.Queries;
using System;

namespace SpiteBattleship
{
    class BattleshipTurnManager : ITurnManager
    {
        private readonly PlayerBattleshipController player;

        public BattleshipTurnManager(PlayerBattleshipController player)
        {
            this.player = player;
        }

        public IActor CurrentController => player;

        private BattleshipTurnPhase currentPhase;
        public ITurnPhase CurrentPhase
        {
            get => currentPhase;
            set
            {
                OnPhaseChanged?.Invoke(currentPhase, value, this);
                currentPhase = (BattleshipTurnPhase)value;
            }
        }

        public event ChangePhase OnPhaseChanged;

        public bool CanBeExecuted(ICommand command)
        {
            return command.Owner == player;
        }

        public void Start()
        {
            CurrentPhase = new PlayerPhase(player);
        }

        public bool CanAct(IActor actor)
        {
            return actor == player && CurrentPhase is PlayerPhase;
        }
    }
}
 