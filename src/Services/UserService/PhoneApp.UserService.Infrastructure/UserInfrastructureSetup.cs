using Microsoft.Extensions.DependencyInjection;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Infrastructure.Users;

namespace PhoneApp.UserService.Infrastructure
{
    public static class UserInfrastructureSetup
    {
        public static IServiceCollection AddUserServiceInfrastructure(this IServiceCollection services)
        {
            #region Ports-Adapters
            services.AddScoped<IUserCommandDataPort, UserCommandDataAdapter>();
            services.AddScoped<IUserQueryDataPort, UserQueryDataAdapter>();
            #endregion
            return services;
        }
    }
}
