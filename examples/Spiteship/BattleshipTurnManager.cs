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
            currentPhase = new PlayerPhase();
        }

        public ITurnController CurrentController => player;

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

        public bool CanControllerAct(ITurnController actor, IAction action)
        {
            throw new System.NotImplementedException();
        }

        public bool DoTurn(IArena arena)
        {
            var action = currentPhase.GetAction(arena, this);
            action.Execute();
            arena.UpdateTeamStandings();
            return arena.AnyTeamHasStanding(TeamStanding.Eliminated);
        }

    }
}
 