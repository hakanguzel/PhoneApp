using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Reports.Exceptions;
using PhoneApp.ReportService.Domain.Users;

namespace PhoneApp.ReportService.Application.Reports.Commands.GenerateReport
{
    internal class GenerateReportCommandHandler : ICommandHandler<GenerateReportCommand, GenerateReportCommandResponse>
    {
        private readonly IReportCommandDataPort _reportCommandDataPort;
        private readonly IReportQueryDataPort _reportQueryDataPort;
        private readonly IUserQueryDataPort _userQueryDataPort;

        public GenerateReportCommandHandler(IReportCommandDataPort reportCommandDataPort, IReportQueryDataPort reportQueryDataPort, IUserQueryDataPort userQueryDataPort)
        {
            _reportCommandDataPort = reportCommandDataPort;
            _reportQueryDataPort = reportQueryDataPort;
            _userQueryDataPort = userQueryDataPort;
        }

        public async Task<GenerateReportCommandResponse> Handle(GenerateReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _reportQueryDataPort.GetAsync(request.ReportId);
            AppRule.ExistsAndActive(report, new ReportNotFoundException(request.ReportId));

            var userCount = await _userQueryDataPort.GetUserCountAsync(report.Location);
            var phoneCount = await _userQueryDataPort.GetPhoneCountAsync(report.Location);
            report.SetUserCount(userCount);
            report.SetPhoneCount(phoneCount);
            report.MarkAsDone();
            var status = await _reportCommandDataPort.SaveAsync(report);
            AppRule.True(status, new ReportNotUpdatedException(request.ReportId));

            return new GenerateReportCommandResponse();
        }
    }
}
