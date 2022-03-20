using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;

namespace PhoneApp.UserService.Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserCommandDataPort _userCommandDataPort;

        public CreateUserCommandHandler(IUserCommandDataPort userCommandDataPort)
        {
            _userCommandDataPort = userCommandDataPort;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.CreateNew(request.Name, request.Surname, request.CompanyName, BaseStatus.Active);
            var userId = await _userCommandDataPort.CreateAsync(user);
            AppRule.NotNegativeOrZero<UserNotCreatedException>(userId);
            return new CreateUserCommandResponse();
        }
    }
}
