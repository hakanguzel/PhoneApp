using Microsoft.Extensions.DependencyInjection;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.Infrastructure.Environments;

namespace PhoneApp.Core.Infrastructure.Business
{
    public static class PublisherSetup
    {
        public static IServiceCollection ConfigureAllPublishersInfra(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            services.ConfigureReportPublisher(applicationSettings);
            return services;
        }
        public static IServiceCollection ConfigureReportPublisher(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            services.AddCap(options =>
            {
                //options.UseEntityFramework<ExampleContext>();
                options.UseSqlServer(applicationSettings.CapSettings.ReportQueueSettings.ConnectionStrings);

                options.UseRabbitMQ(options =>
                {
                    options.ExchangeName = applicationSettings.CapSettings.ReportQueueSettings.Exchange;
                    options.ConnectionFactoryOptions = connectionFactory =>
                    {
                        connectionFactory.Uri = EventHelper.BuildRabbitMQUri(
                            applicationSettings.CapSettings.CapRabbitMqSettings.Protocol,
                            applicationSettings.CapSettings.CapRabbitMqSettings.Username,
                            applicationSettings.CapSettings.CapRabbitMqSettings.Password,
                            applicationSettings.CapSettings.CapRabbitMqSettings.Hostname,
                            applicationSettings.CapSettings.CapRabbitMqSettings.Port);
                    };
                });
            });

            return services;
        }
    }
}
