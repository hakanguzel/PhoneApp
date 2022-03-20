using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Exceptions
{
    public class UserNotCreatedException : BusinessValidationException
    {
        public override string ExceptionId => "93c8acf8-fdc9-4091-b747-d383febfb6f6";
        public override string DisplayMessage => $"Kullanıcı oluşturulamadı!";
        public override string ExceptionContent => $"User Not Created!";
    }
}
