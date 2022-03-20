using Microsoft.EntityFrameworkCore;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.Infrastructure;
using PhoneApp.ReportService.Domain.Users;

namespace PhoneApp.ReportService.Infrastructure.Users
{
    public class UserQueryDataAdapter : IUserQueryDataPort
    {
        private readonly IAppDbContext _dbContext;
        public UserQueryDataAdapter(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> GetUserCountAsync(string location)
        {
            return await _dbContext.UserContacts
                .Where(query => query.Content == location && query.InformationType == InformationType.Address.ToInt() && query.Status == BaseStatus.Active.ToInt())
                .GroupBy(x => x.UserId).CountAsync();
        }
        public async Task<int> GetPhoneCountAsync(string location)
        {
            var userIds = await _dbContext.UserContacts
                .Where(query => query.Content == location && query.InformationType == InformationType.Address.ToInt() && query.Status == BaseStatus.Active.ToInt())
                .Select(s => s.Id)
                .Distinct()
                .ToListAsync();

            return await _dbContext.UserContacts
                .CountAsync(query => userIds.Any(i => i == query.UserId) && query.InformationType == InformationType.Phone.ToInt() && query.Status == BaseStatus.Active.ToInt());
        }

    }
}
