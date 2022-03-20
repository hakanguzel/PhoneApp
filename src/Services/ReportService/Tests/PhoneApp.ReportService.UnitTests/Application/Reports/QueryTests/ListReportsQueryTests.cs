using Moq;
using MoqAssist.Core;
using PhoneApp.ReportService.Application.Reports.Queries.ListReports;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.UnitTests.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Application.Reports.QueryTests
{
    public class ListReportsQueryTests : TestBase
    {
        private readonly MoqAssist<ListReportsQueryHandler> _handlerMoqAssist;
        private readonly ListReportsQueryHandler _handler;

        private readonly Mock<IReportQueryDataPort> _mockReportQueryDataPort;
        public ListReportsQueryTests()
        {
            _handlerMoqAssist = MoqAssist<ListReportsQueryHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockReportQueryDataPort = _handlerMoqAssist.GetMock<IReportQueryDataPort>();
        }
        public static IEnumerable<object[]> ListReportsQuery()
        {
            yield return new object[] {
                new ListReportsQuery
                {

                }
            };
        }
        [Theory]
        [MemberData(nameof(ListReportsQuery))]
        public async Task ListReportsQueryHandler_Should_ReturnResponse_When_Success(ListReportsQuery query)
        {
            _mockReportQueryDataPort.Setup(q => q.GetAsync())
                .ReturnsAsync(It.IsAny<List<Report>>);

            var response = await _handler.Handle(query, cancellationToken: CancellationToken.None);
            Assert.IsType<ListReportsQueryResponse>(response);
        }
    }
}
