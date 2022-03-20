using Microsoft.EntityFrameworkCore;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Domain.Entities.Base;

namespace PhoneApp.Core.Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<UserContactEntity>().ToTable("UserContacts");

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseActivityEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseActivityEntity)entityEntry.Entity).ModifiedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    ((BaseActivityEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                else
                    entityEntry.Property("CreatedAt").IsModified = false;
            }

            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseActivityEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseActivityEntity)entityEntry.Entity).ModifiedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    ((BaseActivityEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                else
                    entityEntry.Property("CreatedAt").IsModified = false;
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserContactEntity> UserContacts { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
    }
}
