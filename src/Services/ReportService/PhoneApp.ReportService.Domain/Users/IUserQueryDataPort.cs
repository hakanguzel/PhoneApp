using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Domain.Users
{
    public interface IUserQueryDataPort : IQueryDataPort
    {
        Task<int> GetUserCountAsync(string location);
        Task<int> GetPhoneCountAsync(string location);
    }
}
