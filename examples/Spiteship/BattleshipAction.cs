using Spite;
using Spite.Actions;
using System;

namespace SpiteBattleship
{
    abstract class BattleshipAction : IAction
    {
        public IArena Context { get; }

        public IActionResult Result { get; protected set; }

        public BattleshipAction(IArena context)
        {
            Context = context;
        }

        public abstract IActionResult Execute();
    }
}
