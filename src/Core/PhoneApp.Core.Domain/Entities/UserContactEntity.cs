using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneApp.Core.Domain.Entities.Base;
using PhoneApp.Core.Domain.Entities.Configurations;

namespace PhoneApp.Core.Domain.Entities
{
    public class UserContactEntity : BaseActivityEntity
    {
        public int UserId { get; set; }
        public int InformationType { get; set; }
        public string Content { get; set; }
        public virtual UserEntity User { get; set; }
    }
    public class UserPhoneEntityConfiguration : IEntityTypeConfiguration<UserContactEntity>
    {
        public void Configure(EntityTypeBuilder<UserContactEntity> builder)
        {
            builder.ToTable("UserContacts");
            builder.Property(x => x.InformationType).IsRequired();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(128);

            builder.HasOne(x => x.User).WithMany(x => x.Contacts).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

            BaseActivityConfiguration.Configure(builder);
        }
    }
}
