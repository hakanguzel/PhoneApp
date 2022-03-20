using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.ReportService.Domain.Reports.Exceptions
{
    public class ReportNotUpdatedException : BusinessValidationException
    {
        private int _reportId;
        public ReportNotUpdatedException(int reportId)
        {
            _reportId = reportId;
        }

        public override string ExceptionId => "6d06445a-90cf-4839-b3b4-447c9dc3d9d7";
        public override string DisplayMessage => $"{_reportId} id bilgisi ile sistemde kayıtlı rapor güncellenemedi!";
        public override string ExceptionContent => $"Report Not Updated! Report Id: {_reportId}";
    }
}
