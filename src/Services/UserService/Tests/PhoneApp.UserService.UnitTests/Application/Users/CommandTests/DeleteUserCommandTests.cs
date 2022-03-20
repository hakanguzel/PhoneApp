using Moq;
using MoqAssist.Core;
using PhoneApp.UserService.Application.Users.Commands.DeleteUser;
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
    public class DeleteUserCommandTests : TestBase
    {
        private readonly MoqAssist<DeleteUserCommandHandler> _handlerMoqAssist;
        private readonly DeleteUserCommandHandler _handler;

        private readonly Mock<IUserQueryDataPort> _mockUserQueryDataPort;
        private readonly Mock<IUserCommandDataPort> _mockUserCommandDataPort;
        public DeleteUserCommandTests()
        {
            _handlerMoqAssist = MoqAssist<DeleteUserCommandHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockUserCommandDataPort = _handlerMoqAssist.GetMock<IUserCommandDataPort>();
            _mockUserQueryDataPort = _handlerMoqAssist.GetMock<IUserQueryDataPort>();
        }
        public static IEnumerable<object[]> DeleteUserCommand()
        {
            yield return new object[] {
                new DeleteUserCommand(1)
            };
        }
        [Theory]
        [MemberData(nameof(DeleteUserCommand))]
        public async Task DeleteUserCommandHandler_Throws_Exception_When_User_Not_Found_Exception(DeleteUserCommand command)
        {
            var user = GetGeneratedDeletedUser();
            _mockUserQueryDataPort.Setup(q => q.GetAsync(command.UserId))
                .ReturnsAsync(user);

            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(DeleteUserCommand))]
        public async Task DeleteUserCommandHandler_Throws_Exception_When_User_Not_Deleted_Exception(DeleteUserCommand command)
        {
            var saveResult = false;
            var user = GetGeneratedActiveUser();
            _mockUserQueryDataPort.Setup(q => q.GetAsync(command.UserId))
                .ReturnsAsync(user);

            _mockUserCommandDataPort.Setup(q => q.SaveAsync(It.IsAny<User>()))
                .ReturnsAsync(saveResult);

            await Assert.ThrowsAsync<UserNotDeletedException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(DeleteUserCommand))]
        public async Task DeleteUserCommandHandler_Should_ReturnResponse_When_Success(DeleteUserCommand command)
        {
            var saveResult = true;
            var user = GetGeneratedActiveUser();

            _mockUserQueryDataPort.Setup(q => q.GetAsync(command.UserId))
                .ReturnsAsync(user);

            _mockUserCommandDataPort.Setup(q => q.SaveAsync(It.IsAny<User>()))
                .ReturnsAsync(saveResult);

            var response = await _handler.Handle(command, cancellationToken: CancellationToken.None);
            Assert.IsType<DeleteUserCommandResponse>(response);
        }
    }
}
