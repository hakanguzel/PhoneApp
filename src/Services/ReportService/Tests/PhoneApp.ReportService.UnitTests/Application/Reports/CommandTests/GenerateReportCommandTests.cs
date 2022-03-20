using Moq;
using MoqAssist.Core;
using PhoneApp.ReportService.Application.Reports.Commands.GenerateReport;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Reports.Exceptions;
using PhoneApp.ReportService.Domain.Users;
using PhoneApp.ReportService.UnitTests.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Application.Reports.CommandTests
{
    public class GenerateReportCommandTests : TestBase
    {
        private readonly MoqAssist<GenerateReportCommandHandler> _handlerMoqAssist;
        private readonly GenerateReportCommandHandler _handler;

        private readonly Mock<IReportCommandDataPort> _mockReportCommandDataPort;
        private readonly Mock<IReportQueryDataPort> _mockReportQueryDataPort;
        private readonly Mock<IUserQueryDataPort> _mockUserQueryDataPort;
        public GenerateReportCommandTests()
        {
            _handlerMoqAssist = MoqAssist<GenerateReportCommandHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockReportCommandDataPort = _handlerMoqAssist.GetMock<IReportCommandDataPort>();
            _mockReportQueryDataPort = _handlerMoqAssist.GetMock<IReportQueryDataPort>();
            _mockUserQueryDataPort = _handlerMoqAssist.GetMock<IUserQueryDataPort>();
        }
        public static IEnumerable<object[]> GenerateReportCommand()
        {
            yield return new object[] {
                new GenerateReportCommand()
                {
                    ReportId = 1
                }
            };
        }
        [Theory]
        [MemberData(nameof(GenerateReportCommand))]
        public async Task GenerateReportCommand_Throws_Exception_When_Report_Not_Found_Exception(GenerateReportCommand command)
        {
            _mockReportQueryDataPort.Setup(q => q.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(default(Report));

            await Assert.ThrowsAsync<ReportNotFoundException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(GenerateReportCommand))]
        public async Task GenerateReportCommand_Throws_Exception_When_Report_Not_Updated_Exception(GenerateReportCommand command)
        {
            var report = GetGeneratedActiveAndDoneReport();
            var userCount = 431;
            var phoneCount = 132;
            var saveStatus = false;

            _mockReportQueryDataPort.Setup(q => q.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(report);
            _mockUserQueryDataPort.Setup(q => q.GetUserCountAsync(report.Location))
                .ReturnsAsync(userCount);
            _mockUserQueryDataPort.Setup(q => q.GetPhoneCountAsync(report.Location))
                .ReturnsAsync(phoneCount);
            _mockReportCommandDataPort.Setup(q => q.SaveAsync(report))
                .ReturnsAsync(saveStatus);

            await Assert.ThrowsAsync<ReportNotUpdatedException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(GenerateReportCommand))]
        public async Task GenerateReportCommand_Should_ReturnResponse_When_Success(GenerateReportCommand command)
        {
            var report = GetGeneratedActiveAndDoneReport();
            var userCount = 431;
            var phoneCount = 132;
            var saveStatus = true;

            _mockReportQueryDataPort.Setup(q => q.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(report);
            _mockUserQueryDataPort.Setup(q => q.GetUserCountAsync(report.Location))
                .ReturnsAsync(userCount);
            _mockUserQueryDataPort.Setup(q => q.GetPhoneCountAsync(report.Location))
                .ReturnsAsync(phoneCount);
            _mockReportCommandDataPort.Setup(q => q.SaveAsync(report))
                .ReturnsAsync(saveStatus);

            var response = await _handler.Handle(command, cancellationToken: CancellationToken.None);
            Assert.IsType<GenerateReportCommandResponse>(response);
        }
    }
}
