namespace PhoneApp.ReportService.Domain.Reports
{
    public enum ReportStatus
    {
        Waiting = 1,
        Done = 2,
        Fail = 3
    }
    public class ReportStatusStrings
    {
        public const string WAITING = "waiting";
        public const string DONE = "done";
        public const string FAIL = "fail";
    }
    public static class ReportStatusExtensions
    {
        public static ReportStatus ToReportStatus(this string status)
        {
            return status switch
            {
                ReportStatusStrings.WAITING => ReportStatus.Waiting,
                ReportStatusStrings.DONE => ReportStatus.Done,
                ReportStatusStrings.FAIL => ReportStatus.Fail
            };
        }
        public static string ToReportStatus(this ReportStatus status)
        {
            return status switch
            {
                ReportStatus.Waiting => ReportStatusStrings.WAITING,
                ReportStatus.Done => ReportStatusStrings.DONE,
                ReportStatus.Fail => ReportStatusStrings.FAIL
            };
        }
    }
}
