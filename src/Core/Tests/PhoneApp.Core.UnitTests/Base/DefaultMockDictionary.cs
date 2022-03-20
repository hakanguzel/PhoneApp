using Moq;
using MoqAssist.Core.Dictionary;
using PhoneApp.Core.Domain.Logging;
using PhoneApp.Core.Infrastructure;

namespace PhoneApp.Core.UnitTests.Base
{
    public class DefaultMockDictionary : MoqAssistDictionary
    {
        public override void RegisterMocks()
        {
            Register(new Mock<IAppDbContext>());

            #region Ports
            Register(new Mock<ILogPort>());
            #endregion
        }
    }
}
