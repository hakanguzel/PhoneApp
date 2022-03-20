using Moq;
using MoqAssist.Core;
using PhoneApp.UserService.Application.Users.Commands.DeleteContact;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;
using PhoneApp.UserService.UnitTests.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.UserService.UnitTests.Application.Users.CommandTests
{
    public class DeleteContactCommandTests : TestBase
    {
        private readonly MoqAssist<DeleteContactCommandHandler> _handlerMoqAssist;
        private readonly DeleteContactCommandHandler _handler;

        private readonly Mock<IUserQueryDataPort> _mockUserQueryDataPort;
        private readonly Mock<IUserCommandDataPort> _mockUserCommandDataPort;
        public DeleteContactCommandTests()
        {
            _handlerMoqAssist = MoqAssist<DeleteContactCommandHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockUserCommandDataPort = _handlerMoqAssist.GetMock<IUserCommandDataPort>();
            _mockUserQueryDataPort = _handlerMoqAssist.GetMock<IUserQueryDataPort>();
        }
        public static IEnumerable<object[]> DeleteContactCommand()
        {
            yield return new object[] {
                new DeleteContactCommand(1)
            };
        }
        [Theory]
        [MemberData(nameof(DeleteContactCommand))]
        public async Task DeleteContactCommandHandler_Throws_Exception_When_User_Not_Found_Exception(DeleteContactCommand command)
        {
            var user = GetGeneratedDeletedUser();
            _mockUserQueryDataPort.Setup(q => q.GetContactAsync(command.ContactId))
                .ReturnsAsync(user);

            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(DeleteContactCommand))]
        public async Task DeleteContactCommandHandler_Throws_Exception_When_Contact_Not_Deleted_Exception(DeleteContactCommand command)
        {
            var saveResult = false;
            var user = GetGeneratedActiveUser();
            _mockUserQueryDataPort.Setup(q => q.GetContactAsync(command.ContactId))
                .ReturnsAsync(user);

            _mockUserCommandDataPort.Setup(q => q.SaveAsync(It.IsAny<User>()))
                .ReturnsAsync(saveResult);

            await Assert.ThrowsAsync<ContactNotDeletedException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(DeleteContactCommand))]
        public async Task DeleteContactCommandHandlerr_Should_ReturnResponse_When_Success(DeleteContactCommand command)
        {
            var saveResult = true;
            var user = GetGeneratedActiveUser();

            _mockUserQueryDataPort.Setup(q => q.GetContactAsync(command.ContactId))
                .ReturnsAsync(user);

            _mockUserCommandDataPort.Setup(q => q.SaveAsync(It.IsAny<User>()))
                .ReturnsAsync(saveResult);

            var response = await _handler.Handle(command, cancellationToken: CancellationToken.None);
            Assert.IsType<DeleteContactCommandResponse>(response);
        }
    }
}
