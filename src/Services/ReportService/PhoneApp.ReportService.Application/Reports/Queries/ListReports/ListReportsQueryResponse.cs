using PhoneApp.ReportService.Domain.Reports;

namespace PhoneApp.ReportService.Application.Reports.Queries.ListReports
{
    public class ListReportsQueryResponse
    {
        public ListReportsQueryResponse() { Reports = new(); }
        public ListReportsQueryResponse(List<Report> reports)
        {
            Reports = reports
                .Select(x => new ReportsQueryResponse(x))
                .ToList();
        }

        public List<ReportsQueryResponse> Reports { get; set; }
    }
    public class ReportsQueryResponse
    {
        public ReportsQueryResponse() { }
        public ReportsQueryResponse(Report report)
        {
            Id = report.Id;
            ReportStatus = report.ReportStatus.ToReportStatus();
            RequestDate = report.CreatedAt;
        }

        public int Id { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string ReportStatus { get; private set; }
    }
}
