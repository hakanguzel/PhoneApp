using PhoneApp.Core.Domain.Abstractions;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users.Contacts;
using PhoneApp.UserService.Domain.Users.Exceptions;

namespace PhoneApp.UserService.Domain.Users
{
    public sealed class User : BaseActivityDomain<int>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string CompanyName { get; private set; }

        private List<UserContact> _contacts = new();
        public IReadOnlyCollection<UserContact> Contacts => _contacts.AsReadOnly();
        public bool IsContentExists(string content) => _contacts.Any(x => x.Content == content);
        public bool IsContactExists(int id) => _contacts.Any(x => x.Id == id);

        public void AddContact(string content, InformationType informationType)
        {
            AppRule.False<UserDomainException>(IsContentExists(content), UserDomainExceptionMessages.CONTENT_ALREADY_EXISTS);
            var contact = UserContact.CreateNew(content, informationType);
            _contacts.Add(contact);
        }
        public void DeleteContact(int id)
        {
            AppRule.True<UserDomainException>(IsContactExists(id), UserDomainExceptionMessages.CONTENT_NOT_EXISTS);
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            contact.MarkAsDeleted();
        }
        public static User Default() => new();
        public static User CreateNew(
            string name,
            string surname,
            string companyName,
            BaseStatus status)
        {
            AppRule.NotNullOrEmpty<UserDomainException>(name, UserDomainExceptionMessages.NAME_CANNOT_BE_NULL_OR_EMPTY);
            AppRule.NotNullOrEmpty<UserDomainException>(surname, UserDomainExceptionMessages.SURNAME_CANNOT_BE_NULL_OR_EMPTY);
            AppRule.NotNullOrEmpty<UserDomainException>(companyName, UserDomainExceptionMessages.COMPANY_NAME_CANNOT_BE_NULL_OR_EMPTY);

            return new User()
            {
                Name = name,
                Surname = surname,
                CompanyName = companyName,
                Status = status
            };
        }
        public static User Map(
            int id,
            BaseStatus status,
            string name,
            string surname,
            string companyName,
            DateTime createdAt,
            DateTime modifiedAt,
            List<UserContact> contacts)
        {
            return new User()
            {
                Id = id,
                Status = status,
                Name = name,
                Surname = surname,
                CompanyName = companyName,
                CreatedAt = createdAt,
                ModifiedAt = modifiedAt,
                _contacts = contacts,
            };
        }



    }
}
