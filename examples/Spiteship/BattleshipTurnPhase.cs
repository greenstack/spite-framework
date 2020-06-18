using Spite;
using Spite.Actions;

namespace SpiteBattleship
{
    abstract class BattleshipTurnPhase : ITurnPhase
    {
        public event ChangePhase OnPhaseChanged;

        public void ChangePhase(ITurnManager manager)
        {
            OnPhaseChanged?.Invoke(this, null, manager);
        }

        public abstract BattleshipAction GetAction(IArena context, BattleshipTurnManager turnManager);
    }
}
