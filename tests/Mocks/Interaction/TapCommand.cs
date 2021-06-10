using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
	public class TapCommand : CommandBase
	{
		public TapCommand(ITappableTeammate teammate, ICommandExecutor executor) 
			: base(new TapAction(teammate), executor)
		{
		}
	}
}
