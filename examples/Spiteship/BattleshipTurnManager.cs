using Spite;

namespace SpiteBattleship
{
    class BattleshipTurnManager : ITurnManager
    {
        private readonly PlayerBattleshipController player;

        public BattleshipTurnManager(PlayerBattleshipController player)
        {
            this.player = player;
        }

        public BattleshipActor CurrentController => player;

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

        public bool CanBeExecuted<TContext>(ICommand<TContext> command)
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

        public bool SendPlayerAttack(BattleshipTeam attacker, BattleshipTeam defender, int x, int y)
        {
            return currentPhase.SendPlayerAttack(attacker, defender, x, y);
        }
    }
}
 