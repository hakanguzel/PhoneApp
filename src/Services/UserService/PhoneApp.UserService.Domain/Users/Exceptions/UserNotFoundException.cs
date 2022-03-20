using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Exceptions
{
    public class UserNotFoundException : BusinessValidationException
    {
        private int _userId;
        public UserNotFoundException(int userId)
        {
            _userId = userId;
        }

        public override string ExceptionId => "e6fc4fbc-7047-41e7-a562-f24b318455e0";
        public override string DisplayMessage => $"{_userId} id bilgisi ile sistemde aktif veya kayıtlı kullanıcı bulunamadı!";
        public override string ExceptionContent => $"User Not Found! User Id: {_userId}";
    }
}
