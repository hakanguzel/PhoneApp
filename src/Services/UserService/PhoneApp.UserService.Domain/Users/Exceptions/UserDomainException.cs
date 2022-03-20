using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Exceptions
{
    public class UserDomainException : DomainException
    {
        private string _displayMessage;
        public UserDomainException(string displayMessage) : base()
        {
            _displayMessage = displayMessage;
        }
        public override string ExceptionId => "46dd1858-8537-4b3e-81a0-7f0b135a2f36";
        public override string DisplayMessage => $"{_displayMessage}";
        public override string ExceptionContent => $"User Domain Exception! {_displayMessage}";
    }
    public static class UserDomainExceptionMessages
    {
        public static readonly string CONTENT_CANNOT_BE_NULL_OR_EMPTY = "İçerik bilgisi boş bırakılamaz.";
        public static readonly string CONTENT_ALREADY_EXISTS = "İçerik bilgisi zaten mevcut.";
        public static readonly string CONTENT_NOT_EXISTS = "İçerik bilgisi mevcut değil.";
        public static readonly string NAME_CANNOT_BE_NULL_OR_EMPTY = "Ad bilgisi boş bırakılamaz.";
        public static readonly string SURNAME_CANNOT_BE_NULL_OR_EMPTY = "Soyad bilgisi boş bırakılamaz.";
        public static readonly string COMPANY_NAME_CANNOT_BE_NULL_OR_EMPTY = "Firma Adı bilgisi boş bırakılamaz.";
    }
}
