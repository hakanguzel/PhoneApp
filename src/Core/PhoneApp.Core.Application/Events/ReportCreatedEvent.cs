using MediatR;

namespace PhoneApp.Core.Application.Events
{
    public class ReportCreatedEvent : INotification
    {
        public ReportCreatedEvent(int reportId) : base()
        {
            ReportId = reportId;
        }

        public int ReportId { get; private set; }
    }
}
