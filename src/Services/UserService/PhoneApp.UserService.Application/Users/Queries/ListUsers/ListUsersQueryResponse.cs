using PhoneApp.UserService.Domain.Users;

namespace PhoneApp.UserService.Application.Users.Queries.ListUsers
{
    public class ListUsersQueryResponse
    {
        public ListUsersQueryResponse() { Users = new(); }
        public ListUsersQueryResponse(List<User> users)
        {
            Users = users
                .Select(x => new UsersQueryResponse(x))
                .ToList();
        }

        public List<UsersQueryResponse> Users { get; set; }
    }
    public class UsersQueryResponse
    {
        public UsersQueryResponse() { }
        public UsersQueryResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            CompanyName = user.CompanyName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string CompanyName { get; private set; }
    }
}
