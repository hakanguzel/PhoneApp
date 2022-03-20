using PhoneApp.ReportService.Domain.Reports;

namespace PhoneApp.ReportService.Application.Reports.Queries.GetReport
{
    public class GetReportQueryResponse
    {
        public GetReportQueryResponse(Report report)
        {
            Id = report.Id;
            ReportStatus = report.ReportStatus.ToReportStatus();
            Location = report.Location;
            UserCount = report.UserCount;
            PhoneCount = report.PhoneCount;
            RequestDate = report.CreatedAt;
        }
        public int Id { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string ReportStatus { get; private set; }
        public string Location { get; set; }
        public int UserCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
