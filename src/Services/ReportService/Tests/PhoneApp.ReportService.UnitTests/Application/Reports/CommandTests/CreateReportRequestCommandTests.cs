using Moq;
using MoqAssist.Core;
using PhoneApp.ReportService.Application.Reports.Commands.CreateReportRequest;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Reports.Exceptions;
using PhoneApp.ReportService.UnitTests.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Application.Reports.CommandTests
{
    public class CreateReportRequestCommandTests : TestBase
    {
        private readonly MoqAssist<CreateReportRequestCommandHandler> _handlerMoqAssist;
        private readonly CreateReportRequestCommandHandler _handler;

        private readonly Mock<IReportCommandDataPort> _mockReportCommandDataPort;
        public CreateReportRequestCommandTests()
        {
            _handlerMoqAssist = MoqAssist<CreateReportRequestCommandHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockReportCommandDataPort = _handlerMoqAssist.GetMock<IReportCommandDataPort>();
        }
        public static IEnumerable<object[]> CreateReportRequestCommand()
        {
            yield return new object[] {
                new CreateReportRequestCommand()
                {
                    Location = "Adana"
                }
            };
        }
        [Theory]
        [MemberData(nameof(CreateReportRequestCommand))]
        public async Task CreateReportRequestCommandHandler_Throws_Exception_When_Report_Not_Created_Exception(CreateReportRequestCommand command)
        {

            _mockReportCommandDataPort.Setup(q => q.CreateAsync(It.IsAny<Report>()))
                .ReturnsAsync(default(int));

            await Assert.ThrowsAsync<ReportNotCreatedException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(CreateReportRequestCommand))]
        public async Task CreateReportRequestCommandHandler_Should_ReturnResponse_When_Success(CreateReportRequestCommand command)
        {
            var expectingReportId = 10;

            _mockReportCommandDataPort.Setup(q => q.CreateAsync(It.IsAny<Report>()))
                .ReturnsAsync(expectingReportId);

            var response = await _handler.Handle(command, cancellationToken: CancellationToken.None);
            Assert.IsType<CreateReportRequestCommandResponse>(response);
        }
    }
}
