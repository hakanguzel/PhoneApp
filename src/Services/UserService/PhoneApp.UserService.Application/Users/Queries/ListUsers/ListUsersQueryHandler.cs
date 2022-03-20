using PhoneApp.Core.Application.Abstractions;
using PhoneApp.UserService.Domain.Users;

namespace PhoneApp.UserService.Application.Users.Queries.ListUsers
{
    internal class ListUsersQueryHandler : IQueryHandler<ListUsersQuery, ListUsersQueryResponse>
    {
        private readonly IUserQueryDataPort _userQueryDataPort;
        public ListUsersQueryHandler(IUserQueryDataPort userQueryDataPort)
        {
            _userQueryDataPort = userQueryDataPort;
        }
        public async Task<ListUsersQueryResponse> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userQueryDataPort.GetAsync();
            return users == null ? new ListUsersQueryResponse() : new ListUsersQueryResponse(users);
        }
    }
}
