using Spite;
using Spite.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteRpg
{
    class RpgTurnManager : Spite.ITurnManager
    {
        public ITurnController CurrentController => throw new NotImplementedException();

        public ITurnPhase CurrentPhase => throw new NotImplementedException();

        public event ChangePhase OnPhaseChanged;

        public bool CanControllerAct(ITurnController actor, IAction action)
        {
            throw new NotImplementedException();
        }

        public bool DoTurn(IArena arena)
        {
            throw new NotImplementedException();
        }
    }
}
