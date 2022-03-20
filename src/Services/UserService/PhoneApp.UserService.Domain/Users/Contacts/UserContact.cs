using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users.Exceptions;

namespace PhoneApp.UserService.Domain.Users.Contacts
{
    public sealed class UserContact : BaseActivityDomain<int>
    {
        private UserContact() { }
        public InformationType InformationType { get; private set; }
        public string Content { get; private set; }
        public static UserContact CreateNew(string content, InformationType informationType)
        {
            AppRule.NotNullOrEmpty<UserDomainException>(content, UserDomainExceptionMessages.CONTENT_CANNOT_BE_NULL_OR_EMPTY);

            return new UserContact()
            {
                InformationType = informationType,
                Content = content
            };
        }

        public static UserContact Map(
            int id,
            BaseStatus status,
            string content,
            InformationType informationType,
            DateTime createdAt,
            DateTime modifiedAt)
        {
            return new UserContact()
            {
                Id = id,
                Status = status,
                Content = content,
                InformationType = informationType,
                CreatedAt = createdAt,
                ModifiedAt = modifiedAt
            };
        }
    }
}
