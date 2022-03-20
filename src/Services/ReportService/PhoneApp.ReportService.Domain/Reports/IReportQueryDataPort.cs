using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Domain.Reports
{
    public interface IReportQueryDataPort : IQueryDataPort
    {
        Task<List<Report>> GetAsync();
        Task<Report> GetAsync(int id);
    }
}
