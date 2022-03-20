using Microsoft.EntityFrameworkCore;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.Infrastructure;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Infrastructure.Extensions.Mappers;

namespace PhoneApp.UserService.Infrastructure.Users
{
    public class UserQueryDataAdapter : IUserQueryDataPort
    {
        private readonly IAppDbContext _dbContext;
        public UserQueryDataAdapter(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAsync()
        {
            var users = await _dbContext.Users
                .Include(x => x.Contacts.Where(q => q.Status == BaseStatus.Active.ToInt()))
                .Where(x => x.Status == BaseStatus.Active.ToInt()).ToListAsync();
            return users.Select(x => x.Map()).ToList();
        }
        public async Task<User> GetAsync(int id)
        {
            var userEntity = await _dbContext.Users
                .Include(x => x.Contacts.Where(q => q.Status == BaseStatus.Active.ToInt()))
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == BaseStatus.Active.ToInt());
            return userEntity.Map();
        }

        public async Task<User> GetContactAsync(int id)
        {
            var userEntity = await _dbContext.Users
                .Include(x => x.Contacts.Where(q => q.Status == BaseStatus.Active.ToInt()))
                .FirstOrDefaultAsync(x => x.Contacts.Any(a => a.Id == id) && x.Status == BaseStatus.Active.ToInt());
            return userEntity.Map();
        }
    }
}
