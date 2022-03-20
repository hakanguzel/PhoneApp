using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneApp.Core.Domain.Entities.Base;
using PhoneApp.Core.Domain.Entities.Configurations;

namespace PhoneApp.Core.Domain.Entities
{
    public class ReportEntity : BaseActivityEntity
    {
        public int ReportStatus { get; set; }
        public string Location { get; set; }
        public int UserCount { get; set; }
        public int PhoneCount { get; set; }
    }
    public class ReportEntityConfiguration : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.ToTable("Reports");
            builder.Property(x => x.ReportStatus).IsRequired();
            builder.Property(x => x.Location).IsRequired().HasMaxLength(128);
            builder.Property(x => x.UserCount).IsRequired();
            builder.Property(x => x.PhoneCount).IsRequired();

            BaseActivityConfiguration.Configure(builder);
        }
    }
}
