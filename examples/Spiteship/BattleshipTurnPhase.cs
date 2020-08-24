using Spite;

namespace SpiteBattleship
{
    abstract class BattleshipTurnPhase : ITurnPhase
    {
        public event ChangePhase OnPhaseChanged;

        public IActor Owner { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="owner">The player this phase belongs to.</param>
        public BattleshipTurnPhase(IActor owner)
        {
            Owner = owner;
        }

        public void ChangePhase(ITurnManager manager)
        {
            OnPhaseChanged?.Invoke(this, null, manager);
        }
        
        public virtual bool SendPlayerAttack(BattleshipTeam attacker, BattleshipTeam defender, int x, int y)
        {
            return false;
        }
    }
}
