using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Domain.Reports
{
    public interface IReportCommandDataPort : ICommandDataPort
    {
        Task<int> CreateAsync(Report report);
        Task<bool> SaveAsync(Report report);
    }
}
