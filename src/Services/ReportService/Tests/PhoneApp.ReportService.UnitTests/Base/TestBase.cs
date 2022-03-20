using PhoneApp.Core.Domain.Base;
using PhoneApp.ReportService.Domain.Reports;
using System;

namespace PhoneApp.ReportService.UnitTests.Base
{
    public class TestBase
    {
        public static Report GetGeneratedActiveAndWaitingReport() => Report.Map(
            id: 1,
            status: BaseStatus.Active,
            reportStatus: ReportStatus.Waiting,
            location: "Adana",
            userCount: 412,
            phoneCount: 323,
            createdAt: DateTime.Now,
            modifiedAt: DateTime.Now
            );
        public static Report GetGeneratedActiveAndDoneReport() => Report.Map(
            id: 1,
            status: BaseStatus.Active,
            reportStatus: ReportStatus.Done,
            location: "Adana",
            userCount: 412,
            phoneCount: 323,
            createdAt: DateTime.Now,
            modifiedAt: DateTime.Now
            );
    }
}
