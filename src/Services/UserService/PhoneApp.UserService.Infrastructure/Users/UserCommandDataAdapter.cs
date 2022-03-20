using PhoneApp.Core.Infrastructure;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Infrastructure.Extensions.Mappers;

namespace PhoneApp.UserService.Infrastructure.Users
{
    public class UserCommandDataAdapter : IUserCommandDataPort
    {
        private readonly IAppDbContext _dbContext;
        public UserCommandDataAdapter(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(User user)
        {
            var userEntity = user.Map();
            await _dbContext.Users.AddAsync(userEntity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? userEntity.Id : 0;
        }

        public async Task<bool> SaveAsync(User user)
        {
            _dbContext.Users.Update(user.Map());
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}
