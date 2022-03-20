using Moq;
using MoqAssist.Core;
using PhoneApp.UserService.Application.Users.Queries.ListUsers;
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
    public class ListUsersQueryTests : TestBase
    {
        private readonly MoqAssist<ListUsersQueryHandler> _handlerMoqAssist;
        private readonly ListUsersQueryHandler _handler;

        private readonly Mock<IUserQueryDataPort> _mockUserQueryDataPort;
        public ListUsersQueryTests()
        {
            _handlerMoqAssist = MoqAssist<ListUsersQueryHandler>.Construct(new DefaultMockDictionary());
            _handler = _handlerMoqAssist.GetConstructors().FirstOrDefault();

            _mockUserQueryDataPort = _handlerMoqAssist.GetMock<IUserQueryDataPort>();
        }
        public static IEnumerable<object[]> ListUsersQuery()
        {
            yield return new object[] {
                new ListUsersQuery{}
            };
        }
        [Theory]
        [MemberData(nameof(ListUsersQuery))]
        public async Task ListUsersQueryHandler_Should_ReturnResponse_When_Success(ListUsersQuery query)
        {
            _mockUserQueryDataPort.Setup(q => q.GetAsync())
                .ReturnsAsync(default(List<User>));

            var response = await _handler.Handle(query, cancellationToken: CancellationToken.None);
            Assert.IsType<ListUsersQueryResponse>(response);
        }
    }
}
