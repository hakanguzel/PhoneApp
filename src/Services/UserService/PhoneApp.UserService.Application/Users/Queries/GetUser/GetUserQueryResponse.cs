using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Contacts;

namespace PhoneApp.UserService.Application.Users.Queries.GetUser
{
    public class GetUserQueryResponse
    {
        public GetUserQueryResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            CompanyName = user.CompanyName;
            Contacts = user.Contacts
                .Select(x => new UserContactsResponse(x))
                .ToList();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string CompanyName { get; private set; }
        public List<UserContactsResponse> Contacts { get; private set; }
    }
    public class UserContactsResponse
    {
        public UserContactsResponse(UserContact contact)
        {
            Id = contact.Id;

            Content = contact.Content;
            InformationType = contact.InformationType.ToString();
        }
        public int Id { get; private set; }
        public string Content { get; private set; }
        public string InformationType { get; private set; }
    }
}
