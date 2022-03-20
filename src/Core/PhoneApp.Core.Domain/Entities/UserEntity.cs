using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneApp.Core.Domain.Entities.Base;
using PhoneApp.Core.Domain.Entities.Configurations;

namespace PhoneApp.Core.Domain.Entities
{
    public class UserEntity : BaseActivityEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<UserContactEntity> Contacts { get; set; }
    }
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(128);
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(256);

            builder.HasMany(x => x.Contacts).WithOne(x => x.User);

            BaseActivityConfiguration.Configure(builder);
        }
    }
}
