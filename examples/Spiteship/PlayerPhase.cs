using Spite;

namespace SpiteBattleship
{
    class PlayerPhase : BattleshipTurnPhase
    {
        public static PlayerBattleshipController player;

        public PlayerPhase(IActor owner) : base(owner)
        {
        }
    }
}
