using Moq;
using MoqAssist.Core;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Infrastructure;
using PhoneApp.UserService.Infrastructure.Users;
using PhoneApp.UserService.UnitTests.Base;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.UserService.UnitTests.Infrastructure.Users
{
    public class UserCommandDataAdapterTests : TestBase
    {
        private readonly MoqAssist<UserCommandDataAdapter> _dataAdapterMoqAssist;
        private readonly UserCommandDataAdapter _dataAdapter;

        private readonly Mock<IAppDbContext> _mockAppDbContext;
        public UserCommandDataAdapterTests()
        {
            _dataAdapterMoqAssist = MoqAssist<UserCommandDataAdapter>.Construct(new DefaultMockDictionary());
            _dataAdapter = _dataAdapterMoqAssist.GetConstructors().FirstOrDefault();

            _mockAppDbContext = _dataAdapterMoqAssist.GetMock<IAppDbContext>();
        }
        [Fact]
        public async Task CreateAsync_Should_Return_Response_When_Success()
        {
            var userId = 1;
            var user = GetGeneratedActiveUser();
            _mockAppDbContext.Setup(q => q.Users.AddAsync(It.IsAny<UserEntity>(), CancellationToken.None));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(userId);

            var actual = await _dataAdapter.CreateAsync(user);
            Assert.Equal(userId, actual);
        }
        [Fact]
        public async Task CreateAsync_Throws_Fail_When_User_Not_Created()
        {
            var userId = 0;
            var user = GetGeneratedActiveUser();
            _mockAppDbContext.Setup(q => q.Users.AddAsync(It.IsAny<UserEntity>(), CancellationToken.None));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(userId);

            var actual = await _dataAdapter.CreateAsync(user);
            Assert.Equal(userId, actual);
        }

        [Fact]
        public async Task SaveAsync_Should_Return_Response_When_Success()
        {
            var userId = 1;
            var user = GetGeneratedActiveUser();
            _mockAppDbContext.Setup(q => q.Users.Update(It.IsAny<UserEntity>()));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(userId);

            var actual = await _dataAdapter.SaveAsync(user);
            Assert.True(actual);
        }
        [Fact]
        public async Task SaveAsync_Throws_Fail_When_User_Not_Saved()
        {
            var userId = 0;
            var user = GetGeneratedActiveUser();
            _mockAppDbContext.Setup(q => q.Users.Update(It.IsAny<UserEntity>()));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(userId);

            var actual = await _dataAdapter.SaveAsync(user);
            Assert.False(actual);
        }
    }
}
