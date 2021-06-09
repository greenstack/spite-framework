using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
    public class AlwaysFailActionCommand : CommandBase
    {
        public AlwaysFailActionCommand(ICommandExecutor user, ISpiteAction action) 
            : base(action, user)
        {
        }
    }
}