using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
    public class AlwaysFailAction : ISpiteAction
    {
        public ITeammate User => throw new System.NotImplementedException();

        public bool IsValid() => true;

        public IReaction UseAndGetReaction()
        {
            return new MockReaction();
        }
    }
}