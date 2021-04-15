using Spite.Interaction;

namespace Spite.UnitTests.Mocks.Interaction
{
    public class AlwaysFailActionCommand : CommandBase
    {
        public AlwaysFailActionCommand(ITeammate user, ISpiteAction action) 
            : base(user, action)
        {
        }
    }
}