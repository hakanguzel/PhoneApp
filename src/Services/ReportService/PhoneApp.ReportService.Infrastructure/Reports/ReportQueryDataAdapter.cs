using Microsoft.EntityFrameworkCore;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.Infrastructure;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Infrastructure.Extensions.Mappers;

namespace PhoneApp.ReportService.Infrastructure.Reports
{
    public class ReportQueryDataAdapter : IReportQueryDataPort
    {
        private readonly IAppDbContext _dbContext;
        public ReportQueryDataAdapter(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Report>> GetAsync()
        {
            var reports = await _dbContext.Reports
                .Where(x => x.Status == BaseStatus.Active.ToInt()).ToListAsync();
            return reports.Select(x => x.Map()).ToList();
        }

        public async Task<Report> GetAsync(int id)
        {
            var reportEntity = await _dbContext.Reports
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == BaseStatus.Active.ToInt());
            return reportEntity.Map();
        }
    }
}
