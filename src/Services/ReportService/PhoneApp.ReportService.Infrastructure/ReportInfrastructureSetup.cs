using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Infrastructure.Reports;
using Microsoft.Extensions.DependencyInjection;
using PhoneApp.ReportService.Domain.Users;
using PhoneApp.ReportService.Infrastructure.Users;

namespace PhoneApp.ReportService.Infrastructure
{
    public static class ReportInfrastructureSetup
    {
        public static IServiceCollection AddReportServiceInfrastructure(this IServiceCollection services)
        {
            #region Ports-Adapters
            services.AddScoped<IReportQueryDataPort, ReportQueryDataAdapter>();
            services.AddScoped<IReportCommandDataPort, ReportCommandDataAdapter>();
            services.AddScoped<IUserQueryDataPort, UserQueryDataAdapter>();
            #endregion
            return services;
        }
    }
}
