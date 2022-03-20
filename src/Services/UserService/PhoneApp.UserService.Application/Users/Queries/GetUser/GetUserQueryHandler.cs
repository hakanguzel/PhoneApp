using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;

namespace PhoneApp.UserService.Application.Users.Queries.GetUser
{
    internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, GetUserQueryResponse>
    {
        private readonly IUserQueryDataPort _userQueryDataPort;
        public GetUserQueryHandler(IUserQueryDataPort userQueryDataPort)
        {
            _userQueryDataPort = userQueryDataPort;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userQueryDataPort.GetAsync(request.UserId);
            AppRule.ExistsAndActive(user, new UserNotFoundException(request.UserId));

            return new GetUserQueryResponse(user);
        }
    }
}
