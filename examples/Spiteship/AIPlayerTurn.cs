using Spite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteBattleship
{
    class AIPlayerTurn : BattleshipTurnPhase
    {
        public AIPlayerTurn(IActor owner) : base(owner)
        {
        }
    }
}
