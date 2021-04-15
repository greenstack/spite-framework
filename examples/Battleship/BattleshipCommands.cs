using Spite;
using Spite.Interaction;

namespace Battleship
{
    class ForfeitCommand : CommandBase
    {
        public ForfeitCommand(ITeam forfeitingTeam)
            : base(null, new ForfeitAction(forfeitingTeam))
        {
        }

        public override IReaction Execute()
        {
            // Why isn't this the default in the command base?
            return action.UseAndGetReaction();
        }
    }
}
