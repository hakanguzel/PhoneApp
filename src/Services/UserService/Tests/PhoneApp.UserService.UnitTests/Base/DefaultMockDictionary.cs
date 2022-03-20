using MediatR;
using Moq;
using MoqAssist.Core.Dictionary;
using PhoneApp.Core.Domain.Logging;
using PhoneApp.Core.Infrastructure;
using PhoneApp.UserService.Domain.Users;

namespace PhoneApp.UserService.UnitTests.Base
{
    public class DefaultMockDictionary : MoqAssistDictionary
    {
        public override void RegisterMocks()
        {
            Register(new Mock<IAppDbContext>());

            #region Ports
            Register(new Mock<IUserQueryDataPort>());
            Register(new Mock<IUserCommandDataPort>());
            Register(new Mock<IMediator>());
            Register(new Mock<ILogPort>());
            #endregion
        }
    }
}
