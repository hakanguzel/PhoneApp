using PhoneApp.Core.Application.Abstractions;
using PhoneApp.ReportService.Domain.Reports;

namespace PhoneApp.ReportService.Application.Reports.Queries.ListReports
{
    internal class ListReportsQueryHandler : IQueryHandler<ListReportsQuery, ListReportsQueryResponse>
    {
        private readonly IReportQueryDataPort _reportQueryDataPort;
        public ListReportsQueryHandler(IReportQueryDataPort reportQueryDataPort)
        {
            _reportQueryDataPort = reportQueryDataPort;
        }
        public async Task<ListReportsQueryResponse> Handle(ListReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _reportQueryDataPort.GetAsync();
            return reports == null ? new ListReportsQueryResponse() : new ListReportsQueryResponse(reports);
        }
    }
}
