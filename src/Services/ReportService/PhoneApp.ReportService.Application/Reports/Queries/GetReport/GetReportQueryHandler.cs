using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Reports.Exceptions;

namespace PhoneApp.ReportService.Application.Reports.Queries.GetReport
{
    internal class GetReportQueryHandler : IQueryHandler<GetReportQuery, GetReportQueryResponse>
    {
        private readonly IReportQueryDataPort _reportQueryDataPort;
        public GetReportQueryHandler(IReportQueryDataPort reportQueryDataPort)
        {
            _reportQueryDataPort = reportQueryDataPort;
        }
        public async Task<GetReportQueryResponse> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            var report = await _reportQueryDataPort.GetAsync(request.ReportId);
            AppRule.ExistsAndActive(report, new ReportNotFoundException(request.ReportId));
            AppRule.True(report.ReportStatus == ReportStatus.Done, new ReportNotReadyException(request.ReportId));

            return new GetReportQueryResponse(report);
        }
    }
}
