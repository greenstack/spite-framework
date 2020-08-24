using Spite;

namespace SpiteBattleship
{
    class PlayerPhase : BattleshipTurnPhase
    {
        public static PlayerBattleshipController player;

        public PlayerPhase(IActor owner) : base(owner)
        {
        }

        public override bool SendPlayerAttack(BattleshipTeam attacker, BattleshipTeam defender, int x, int y)
        {
            if (attacker != player.Team) return false;
            var result = defender.ReceiveGuess(x, y);
            attacker.InformOfGuessAt(x, y, result);
            return result;
        }
    }
}
