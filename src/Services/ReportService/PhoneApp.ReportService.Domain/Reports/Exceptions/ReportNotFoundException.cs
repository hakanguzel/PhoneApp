using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.ReportService.Domain.Reports.Exceptions
{
    public class ReportNotFoundException : BusinessValidationException
    {
        private int _reportId;
        public ReportNotFoundException(int reportId)
        {
            _reportId = reportId;
        }

        public override string ExceptionId => "e9efa743-0fff-4965-b004-21a144e5480c";
        public override string DisplayMessage => $"{_reportId} id bilgisi ile sistemde aktif veya kayıtlı rapor bulunamadı!";
        public override string ExceptionContent => $"Report Not Found! Report Id: {_reportId}";
    }
}
