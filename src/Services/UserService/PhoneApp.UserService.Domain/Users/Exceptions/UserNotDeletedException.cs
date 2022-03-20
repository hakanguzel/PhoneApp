using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Exceptions
{
    public class UserNotDeletedException : BusinessValidationException
    {
        private int _userId;
        public UserNotDeletedException(int userId)
        {
            _userId = userId;
        }

        public override string ExceptionId => "e019cc8b-75c6-47f4-8fef-304dc1f42d01";
        public override string DisplayMessage => $"{_userId} id bilgisi ile sistemde kayıtlı kulanıcı silinemedi!";
        public override string ExceptionContent => $"User Not Deleted! User Id: {_userId}";
    }
}
