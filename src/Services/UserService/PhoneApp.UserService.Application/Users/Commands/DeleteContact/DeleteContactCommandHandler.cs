using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;

namespace PhoneApp.UserService.Application.Users.Commands.DeleteContact
{
    internal class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand, DeleteContactCommandResponse>
    {
        private readonly IUserQueryDataPort _userQueryDataPort;
        private readonly IUserCommandDataPort _userCommandDataPort;

        public DeleteContactCommandHandler(IUserQueryDataPort userQueryDataPort, IUserCommandDataPort userCommandDataPort)
        {
            _userQueryDataPort = userQueryDataPort;
            _userCommandDataPort = userCommandDataPort;
        }

        public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryDataPort.GetContactAsync(request.ContactId);
            AppRule.ExistsAndActive(user, new UserNotFoundException(user.Id));

            user.DeleteContact(request.ContactId);

            var result = await _userCommandDataPort.SaveAsync(user);
            AppRule.True(result, new ContactNotDeletedException(user.Id));

            return new DeleteContactCommandResponse();
        }
    }
}
