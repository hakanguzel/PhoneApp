using Moq;
using MoqAssist.Core;
using System.Collections.Generic;
using System.Linq;
using PhoneApp.ReportService.UnitTests.Base;
using PhoneApp.ReportService.Application.Reports.Queries.GetReport;
using PhoneApp.ReportService.Domain.Reports;
using Xunit;
using System.Threading.Tasks;
using PhoneApp.ReportService.Domain.Reports.Exceptions;
using System.Threading;

namespace PhoneApp.ReportService.UnitTests.Application.Reports.QueryTests
{
    public class GetReportQueryTests : TestBase
    {
        private readonly MoqAssist<GetReportQueryHandler> _handlerMoqAssist;
        private readonly GetReportQueryHandler _handler;

        private readonly Mock<IReportQueryDataPort> _mockReportQueryDataPort;
        public GetReportQueryTests()
        {
            _handlerMoqAssist = MoqAssist<GetReportQueryHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockReportQueryDataPort = _handlerMoqAssist.GetMock<IReportQueryDataPort>();
        }
        public static IEnumerable<object[]> GetReportQuery()
        {
            yield return new object[] {
                new GetReportQuery(1)
            };
        }
        [Theory]
        [MemberData(nameof(GetReportQuery))]
        public async Task GetReportQueryHandler_Throws_Exception_When_Report_Not_Found_Exception(GetReportQuery query)
        {

            _mockReportQueryDataPort.Setup(q => q.GetAsync(query.ReportId))
                .ReturnsAsync(default(Report));

            await Assert.ThrowsAsync<ReportNotFoundException>(async () => await _handler.Handle(query, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(GetReportQuery))]
        public async Task GetReportQueryHandler_Throws_Exception_When_Report_Not_Ready_Exception(GetReportQuery query)
        {
            var report = GetGeneratedActiveAndWaitingReport();

            _mockReportQueryDataPort.Setup(q => q.GetAsync(query.ReportId))
                .ReturnsAsync(report);

            await Assert.ThrowsAsync<ReportNotReadyException>(async () => await _handler.Handle(query, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(GetReportQuery))]
        public async Task GetReportQueryHandler_Should_ReturnResponse_When_Success(GetReportQuery query)
        {
            var report = GetGeneratedActiveAndDoneReport();

            _mockReportQueryDataPort.Setup(q => q.GetAsync(query.ReportId))
                .ReturnsAsync(report);

            var response = await _handler.Handle(query, cancellationToken: CancellationToken.None);
            Assert.IsType<GetReportQueryResponse>(response);
        }
    }
}
