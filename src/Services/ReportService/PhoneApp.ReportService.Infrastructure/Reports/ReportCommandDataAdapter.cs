using PhoneApp.Core.Infrastructure;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Infrastructure.Extensions.Mappers;

namespace PhoneApp.ReportService.Infrastructure.Reports
{
    public class ReportCommandDataAdapter : IReportCommandDataPort
    {
        private readonly IAppDbContext _dbContext;
        public ReportCommandDataAdapter(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(Report report)
        {
            var reportEntity = report.Map();
            await _dbContext.Reports.AddAsync(reportEntity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? reportEntity.Id : 0;
        }

        public async Task<bool> SaveAsync(Report report)
        {
            _dbContext.Reports.Update(report.Map());
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}
