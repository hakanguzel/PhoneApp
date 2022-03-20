using PhoneApp.ReportService.Domain.Reports;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Domain
{
    public class ReportStatusTests
    {
        [Fact]
        public void ToReportStatus_Should_Be_Successful_String()
        {
            var waitingStatus = ReportStatus.Waiting;
            var doneStatus = ReportStatus.Done;
            var failStatus = ReportStatus.Fail;

            Assert.True(waitingStatus.ToReportStatus() == ReportStatusStrings.WAITING);
            Assert.True(doneStatus.ToReportStatus() == ReportStatusStrings.DONE);
            Assert.True(failStatus.ToReportStatus() == ReportStatusStrings.FAIL);
        }
        [Fact]
        public void ToReportStatus_Should_Be_Successful_Enum()
        {
            var waitingStatus = ReportStatusStrings.WAITING;
            var doneStatus = ReportStatusStrings.DONE;
            var failStatus = ReportStatusStrings.FAIL;

            Assert.True(waitingStatus.ToReportStatus() == ReportStatus.Waiting);
            Assert.True(doneStatus.ToReportStatus() == ReportStatus.Done);
            Assert.True(failStatus.ToReportStatus() == ReportStatus.Fail);
        }
    }
}
