using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
    public class ReactionAction : ISpiteAction
    {
        public ITeammate User => null;

        public bool IsValid() => true;

        public IReaction UseAndGetReaction()
        {
            return new MockReaction();
        }
    }
}
