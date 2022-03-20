using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.UserService.Application.Users.Queries.ListUsers
{
    public class ListUsersQuery : IQuery<ListUsersQueryResponse>
    {
    }
    public class ListUsersQueryValidator : AbstractValidator<ListUsersQuery>
    {
        public ListUsersQueryValidator()
        {
        }
    }
}
