using Moq;
using MoqAssist.Core;
using PhoneApp.UserService.Application.Users.Commands.CreateContact;
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
    public class CreateContactCommandTests : TestBase
    {
        private readonly MoqAssist<CreateContactCommandHandler> _handlerMoqAssist;
        private readonly CreateContactCommandHandler _handler;

        private readonly Mock<IUserQueryDataPort> _mockUserQueryDataPort;
        private readonly Mock<IUserCommandDataPort> _mockUserCommandDataPort;
        public CreateContactCommandTests()
        {
            _handlerMoqAssist = MoqAssist<CreateContactCommandHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockUserQueryDataPort = _handlerMoqAssist.GetMock<IUserQueryDataPort>();
            _mockUserCommandDataPort = _handlerMoqAssist.GetMock<IUserCommandDataPort>();
        }
        public static IEnumerable<object[]> CreateContactCommand()
        {
            yield return new object[] {
                new CreateContactCommand()
                {
                    UserId = 1,
                    Contact= new List<Contact>
                    {
                        new Contact
                        {
                            InformationType = "address",
                            Content = "Adana"
                        }
                    }
                }
            };
        }
        [Theory]
        [MemberData(nameof(CreateContactCommand))]
        public async Task CreateContactCommandHandler_Throws_Exception_When_User_Not_Found_Exception(CreateContactCommand command)
        {

            _mockUserQueryDataPort.Setup(q => q.GetAsync(command.UserId))
                .ReturnsAsync(default(User));

            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(CreateContactCommand))]
        public async Task CreateContactCommandHandler_Throws_Exception_When_User_Contact_Not_Updated_Exception(CreateContactCommand command)
        {
            var saveStatus = false;
            var activeUser = GetGeneratedActiveUser();
            _mockUserQueryDataPort.Setup(q => q.GetAsync(command.UserId))
                .ReturnsAsync(activeUser);

            _mockUserCommandDataPort.Setup(q => q.SaveAsync(It.IsAny<User>()))
                .ReturnsAsync(saveStatus);

            await Assert.ThrowsAsync<UserContactNotUpdatedException>(async () => await _handler.Handle(command, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(CreateContactCommand))]
        public async Task CreateContactCommandHandler_Should_ReturnResponse_When_Success(CreateContactCommand command)
        {
            var saveStatus = true;
            var activeUser = GetGeneratedActiveUser();
            _mockUserQueryDataPort.Setup(q => q.GetAsync(command.UserId))
                .ReturnsAsync(activeUser);

            _mockUserCommandDataPort.Setup(q => q.SaveAsync(It.IsAny<User>()))
                .ReturnsAsync(saveStatus);

            var response = await _handler.Handle(command, cancellationToken: CancellationToken.None);
            Assert.IsType<CreateContactCommandResponse>(response);
        }
    }
}
