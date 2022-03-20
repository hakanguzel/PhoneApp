using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneApp.Core.Domain.Logging;
using PhoneApp.Core.Infrastructure.Business;
using PhoneApp.Core.Infrastructure.Environments;
using PhoneApp.Core.Infrastructure.Logging;

namespace PhoneApp.Core.Infrastructure
{
    public static class CoreInfrastructureSetup
    {
        public static IServiceCollection ConfigureCoreInfrastructure(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            services.AddEfDatabaseClient(applicationSettings);
            services.ConfigureAllPublishersInfra(applicationSettings);
            services.AddSingleton<ILogPort, ConsoleLogAdapter>();

            return services;
        }
        public static IServiceCollection AddEfDatabaseClient(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(applicationSettings.MssqlSettings.ConnectionStrings, m => m.MigrationsAssembly("PhoneApp.Core.Infrastructure")
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
            }, ServiceLifetime.Scoped);

            services.AddScoped<IAppDbContext, AppDbContext>();

            return services;
        }
    }
}
