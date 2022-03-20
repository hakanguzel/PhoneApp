using Moq;
using MoqAssist.Core;
using PhoneApp.UserService.Application.Users.Commands.CreateUser;
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
    public class CreateUserCommandTests : TestBase
    {
        private readonly MoqAssist<CreateUserCommandHandler> _handlerMoqAssist;
        private readonly CreateUserCommandHandler _handler;

        private readonly Mock<IUserCommandDataPort> _mockUserCommandDataPort;
        public CreateUserCommandTests()
        {
            _handlerMoqAssist = MoqAssist<CreateUserCommandHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockUserCommandDataPort = _handlerMoqAssist.GetMock<IUserCommandDataPort>();
        }
        public static IEnumerable<object[]> CreateUserCommand()
        {
            yield return new object[] {
                new CreateUserCommand()
                {
                    Name = "Hakan",
                    Surname = "GÜZEL",
                    CompanyName = "Farmazon"
                }
            };
        }
        [Theory]
        [MemberData(nameof(CreateUserCommand))]
        public async Task CreateUserCommandHandler_Throws_Exception_When_User_Not_Created_Exception(CreateUserCommand command)
        {

            _mockUserCommandDataPort.Setup(q => q.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(default(int));

            await Assert.ThrowsAsync<UserNotCreatedException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(CreateUserCommand))]
        public async Task CreateUserCommandHandler_Should_ReturnResponse_When_Success(CreateUserCommand command)
        {
            var userId = 1;

            _mockUserCommandDataPort.Setup(q => q.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(userId);

            var response = await _handler.Handle(command, cancellationToken: CancellationToken.None);
            Assert.IsType<CreateUserCommandResponse>(response);
        }
    }
}
