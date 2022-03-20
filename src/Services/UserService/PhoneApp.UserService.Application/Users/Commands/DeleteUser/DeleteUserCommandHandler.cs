using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;

namespace PhoneApp.UserService.Application.Users.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, DeleteUserCommandResponse>
    {
        private readonly IUserQueryDataPort _userQueryDataPort;
        private readonly IUserCommandDataPort _userCommandDataPort;

        public DeleteUserCommandHandler(IUserQueryDataPort userQueryDataPort, IUserCommandDataPort userCommandDataPort)
        {
            _userQueryDataPort = userQueryDataPort;
            _userCommandDataPort = userCommandDataPort;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryDataPort.GetAsync(request.UserId);
            AppRule.ExistsAndActive(user, new UserNotFoundException(request.UserId));

            user.MarkAsDeleted();

            var result = await _userCommandDataPort.SaveAsync(user);
            AppRule.True(result, new UserNotDeletedException(request.UserId));

            return new DeleteUserCommandResponse();
        }
    }
}
