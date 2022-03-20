using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.ReportService.Domain.Reports.Exceptions
{
    public class ReportDomainException : DomainException
    {
        private string _displayMessage;
        public ReportDomainException(string displayMessage) : base()
        {
            _displayMessage = displayMessage;
        }
        public override string ExceptionId => "fa93a14b-1bbb-47a0-b3a9-aaad9dc6c071";
        public override string DisplayMessage => $"{_displayMessage}";
        public override string ExceptionContent => $"Report Domain Exception! {_displayMessage}";
    }
    public static class ReportDomainExceptionMessages
    {
        public static readonly string LOCATION_CANNOT_BE_NULL_OR_EMPTY = "Lokasyon boş bırakılamaz.";
        public static readonly string USER_COUNT_CANNOT_BE_NEGATIVE = "User sayısı değeri sıfırdan küçük olamaz.";
        public static readonly string PHONE_COUNT_CANNOT_BE_NEGATIVE = "Telefon sayısı değeri sıfırdan küçük olamaz.";
    }
}
