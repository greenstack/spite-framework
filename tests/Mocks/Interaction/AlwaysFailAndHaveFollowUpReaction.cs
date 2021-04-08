using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
    public class AlwaysFailAndHaveFollowUpAction : ISpiteAction
    {
        public ITeammate User => null;

        public bool IsValid() => true;

        public IReaction UseAndGetReaction()
        {
            return new MockReaction {
                FollowUpAction = new ReactionAction(),
            };
        }
    }
}
