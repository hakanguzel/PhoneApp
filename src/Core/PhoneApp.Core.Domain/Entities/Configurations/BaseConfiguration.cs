using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneApp.Core.Domain.Entities.Base;

namespace PhoneApp.Core.Domain.Entities.Configurations
{
    internal static class BaseConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
