using DotNetCore.CAP;
using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Application.Events;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Reports.Exceptions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PhoneApp.ReportService.UnitTests")]
namespace PhoneApp.ReportService.Application.Reports.Commands.CreateReportRequest
{
    internal class CreateReportRequestCommandHandler : ICommandHandler<CreateReportRequestCommand, CreateReportRequestCommandResponse>
    {
        private readonly IReportCommandDataPort _reportCommandDataPort;
        private readonly ICapPublisher _capPublisher;

        public CreateReportRequestCommandHandler(IReportCommandDataPort reportCommandDataPort, ICapPublisher capPublisher)
        {
            _reportCommandDataPort = reportCommandDataPort;
            _capPublisher = capPublisher;
        }

        public async Task<CreateReportRequestCommandResponse> Handle(CreateReportRequestCommand request, CancellationToken cancellationToken)
        {
            var report = Report.CreateNew(request.Location, ReportStatus.Waiting, BaseStatus.Active);
            var reportId = await _reportCommandDataPort.CreateAsync(report);
            AppRule.NotNegativeOrZero<ReportNotCreatedException>(reportId);


            await _capPublisher.PublishAsync<ReportCreatedEvent>("report.event", new ReportCreatedEvent(reportId));

            return new CreateReportRequestCommandResponse();
        }
    }
}
