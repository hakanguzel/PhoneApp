using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.ReportService.Domain.Reports.Exceptions
{
    public class ReportNotCreatedException : BusinessValidationException
    {
        public override string ExceptionId => "5d6f385b-92ae-42ab-a4d2-f7bd6f3d0940";
        public override string DisplayMessage => $"Rapor talebi oluşturulamadı!";
        public override string ExceptionContent => $"Failed to create report request!";
    }
}
