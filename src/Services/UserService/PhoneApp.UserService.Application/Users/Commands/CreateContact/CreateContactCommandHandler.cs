using PhoneApp.Core.Application.Abstractions;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PhoneApp.UserService.UnitTests")]
namespace PhoneApp.UserService.Application.Users.Commands.CreateContact
{
    internal class CreateContactCommandHandler : ICommandHandler<CreateContactCommand, CreateContactCommandResponse>
    {
        private readonly IUserQueryDataPort _userQueryDataPort;
        private readonly IUserCommandDataPort _userCommandDataPort;

        public CreateContactCommandHandler(IUserQueryDataPort userQueryDataPort, IUserCommandDataPort userCommandDataPort)
        {
            _userQueryDataPort = userQueryDataPort;
            _userCommandDataPort = userCommandDataPort;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueryDataPort.GetAsync(request.UserId);
            AppRule.ExistsAndActive(user, new UserNotFoundException(request.UserId));

            request.Contact.ForEach(c => user.AddContact(c.Content, c.InformationType.ToInformationType()));

            var status = await _userCommandDataPort.SaveAsync(user);
            AppRule.True(status, new UserContactNotUpdatedException(user.Id));

            return new CreateContactCommandResponse();
        }
    }
}
