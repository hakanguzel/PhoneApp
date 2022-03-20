using PhoneApp.Core.Domain.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Exceptions
{
    public class ContactNotDeletedException : BusinessValidationException
    {
        private int _userId;
        public ContactNotDeletedException(int userId)
        {
            _userId = userId;
        }

        public override string ExceptionId => "d41288eb-2fd0-44cd-8832-33306774de0f";
        public override string DisplayMessage => $"{_userId} id bilgisi ile sistemde kayıtlı kulanıcının iletişim bilgisi silinemedi!";
        public override string ExceptionContent => $"Contact Not Deleted! User Id: {_userId}";
    }
}
