using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.ReportService.Domain.Reports.Exceptions
{
    public class ReportNotReadyException : BusinessValidationException
    {
        private int _reportId;
        public ReportNotReadyException(int reportId)
        {
            _reportId = reportId;
        }

        public override string ExceptionId => "e2be6b5d-8646-4a5a-a722-f7724d5f6870";
        public override string DisplayMessage => $"{_reportId} id bilgisi ile sistemde tamamlanmış rapor bulunamadı!";
        public override string ExceptionContent => $"Report Not Ready! Report Id: {_reportId}";
    }
}
