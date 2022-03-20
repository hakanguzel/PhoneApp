using Moq;
using MoqAssist.Core;
using PhoneApp.UserService.Application.Users.Queries.GetUser;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Exceptions;
using PhoneApp.UserService.UnitTests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.UserService.UnitTests.Application.Users.QueryTests
{
    public class GetUserQueryTests : TestBase
    {
        private readonly MoqAssist<GetUserQueryHandler> _handlerMoqAssist;
        private readonly GetUserQueryHandler _handler;

        private readonly Mock<IUserQueryDataPort> _mockUserQueryDataPort;
        public GetUserQueryTests()
        {
            _handlerMoqAssist = MoqAssist<GetUserQueryHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockUserQueryDataPort = _handlerMoqAssist.GetMock<IUserQueryDataPort>();
        }
        public static IEnumerable<object[]> GetUserQuery()
        {
            yield return new object[] {
                new GetUserQuery(1)
            };
        }
        [Theory]
        [MemberData(nameof(GetUserQuery))]
        public async Task GetUserQueryHandler_Throws_Exception_When_User_Not_Found_Exception(GetUserQuery query)
        {

            _mockUserQueryDataPort.Setup(q => q.GetAsync(query.UserId))
                .ReturnsAsync(default(User));

            await Assert.ThrowsAsync<UserNotFoundException>(async () => await _handler.Handle(query, cancellationToken: CancellationToken.None));
        }
        [Theory]
        [MemberData(nameof(GetUserQuery))]
        public async Task GetUserQueryHandler_Should_ReturnResponse_When_Success(GetUserQuery query)
        {
            var user = GetGeneratedActiveUser();

            _mockUserQueryDataPort.Setup(q => q.GetAsync(query.UserId))
                .ReturnsAsync(user);

            var response = await _handler.Handle(query, cancellationToken: CancellationToken.None);
            Assert.IsType<GetUserQueryResponse>(response);
        }
    }
}
