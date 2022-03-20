using DotNetCore.CAP;
using MediatR;
using Moq;
using MoqAssist.Core.Dictionary;
using PhoneApp.Core.Domain.Logging;
using PhoneApp.Core.Infrastructure;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Users;

namespace PhoneApp.ReportService.UnitTests.Base
{
    public class DefaultMockDictionary : MoqAssistDictionary
    {
        public override void RegisterMocks()
        {
            Register(new Mock<IAppDbContext>());

            #region Ports
            Register(new Mock<IUserQueryDataPort>());
            Register(new Mock<IReportQueryDataPort>());
            Register(new Mock<IReportCommandDataPort>());
            Register(new Mock<IMediator>());
            Register(new Mock<ILogPort>());
            Register(new Mock<ICapPublisher>());
            #endregion
        }
    }
}
