using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneApp.Core.Domain.Entities.Base;

namespace PhoneApp.Core.Domain.Entities.Configurations
{
    internal static class BaseActivityConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> builder) where T : BaseActivityEntity
        {
            BaseConfiguration.Configure<T>(builder);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.ModifiedAt).IsRequired();
        }
    }
}
