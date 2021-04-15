using System;
using Spite.Interaction;
using Spite.Turns;

namespace Battleship
{
    /// <summary>
    /// The player's phase.
    /// </summary>
    class PlayerPhase : ITurnPhase
    {
        private readonly BattleshipTeam playerTeam;

        private readonly BattleshipTeam enemyTeam;

        public PlayerPhase(BattleshipTeam playerTeam, BattleshipTeam enemyTeam)
        {
            this.playerTeam = playerTeam;
            this.enemyTeam = enemyTeam;
        }

        public event ChangePhase OnPhaseChanged;

        public void ChangePhase(ITurnManager manager)
        {
            throw new NotImplementedException();
        }

        public bool IsCommandExecutableThisPhase(CommandBase command)
        {
            throw new NotImplementedException();
        }
    }

    class EnemyPhase : ITurnPhase
    {
        private readonly BattleshipTeam enemyTeam;

        private readonly BattleshipTeam playerTeam;

        public EnemyPhase(BattleshipTeam enemyTeam, BattleshipTeam playerTeam)
        {
            this.enemyTeam = enemyTeam;
            this.playerTeam = playerTeam;
        }

        public event ChangePhase OnPhaseChanged;

        public void ChangePhase(ITurnManager manager)
        {
            throw new NotImplementedException();
        }

        public bool IsCommandExecutableThisPhase(CommandBase command)
        {
            
        }
    }
}
