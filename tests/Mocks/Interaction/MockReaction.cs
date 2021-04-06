using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
    public class MockReaction : IReaction<int>
    {
        public ISpiteAction FollowUpAction {get; set;} = null;

        public bool ActionSuccessful { get; set; } = false;

        public int ReactionData { get; set; } = 0;

        public object GetReactionData()
        {
            return ReactionData;
        }

        public TReactionData GetReactionData<TReactionData>()
        {
            return (TReactionData)GetReactionData();
        }
    }
}