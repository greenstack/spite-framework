using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
	class TapAction : ISpiteAction
	{
		public ITeammate User { get; }

		public TapAction(ITappableTeammate tappable)
		{
			User = tappable;
		}

		public bool IsValid() => true;

		public IReaction UseAndGetReaction()
		{
			(User as ITappableTeammate).Tap();
			return new MockReaction();
		}
	}
}
