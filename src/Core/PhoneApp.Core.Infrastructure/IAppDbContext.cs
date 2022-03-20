using Microsoft.EntityFrameworkCore;
using PhoneApp.Core.Domain.Entities;

namespace PhoneApp.Core.Infrastructure
{
    public interface IAppDbContext : IDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<UserContactEntity> UserContacts { get; set; }
        DbSet<ReportEntity> Reports { get; set; }
    }
}
