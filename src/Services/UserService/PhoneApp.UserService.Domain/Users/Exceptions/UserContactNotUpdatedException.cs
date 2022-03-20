using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Exceptions
{
    public class UserContactNotUpdatedException : BusinessValidationException
    {
        private int _userId;
        public UserContactNotUpdatedException(int userId)
        {
            _userId = userId;
        }

        public override string ExceptionId => "286a01f5-8826-40ee-9280-d8a04a2e438a";
        public override string DisplayMessage => $"{_userId} id bilgisi ile sistemde kayıtlı kullanıcının iletişim bilgileri oluşturulamadı!";
        public override string ExceptionContent => $"User Contact Not Created! User Id: {_userId}";
    }
}
