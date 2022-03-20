using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.ReportService.Domain.Reports;

namespace PhoneApp.ReportService.Infrastructure.Extensions.Mappers
{
    public static partial class DomainMapper
    {
        public static ReportEntity Map(this Report domain)
        {
            return new ReportEntity()
            {
                Id = domain.Id,
                ReportStatus = domain.ReportStatus.ToInt(),
                Status = domain.Status.ToInt(),
                Location = domain.Location,
                UserCount = domain.UserCount,
                PhoneCount = domain.PhoneCount,
                CreatedAt = domain.CreatedAt,
                ModifiedAt = domain.ModifiedAt
            };
        }

        public static Report Map(this ReportEntity entity)
        {
            if (entity == null)
                return Report.Default();

            return Report.Map(entity.Id,
                entity.Status.ToEnum<BaseStatus>(),
                entity.ReportStatus.ToEnum<ReportStatus>(),
                entity.Location,
                entity.UserCount,
                entity.PhoneCount,
                entity.CreatedAt,
                entity.ModifiedAt);
        }
    }
}
