using MediatR;
using PhoneApp.Consumer.Report.Subscribers;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.Core.Infrastructure;
using PhoneApp.Core.Infrastructure.Environments;
using PhoneApp.Core.Infrastructure.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//---Services-Related Configurations---//
var applicationSettings = new ApplicationSettings();

#region Binding Settings
builder.Configuration.Bind("ApplicationSettings", applicationSettings);
builder.Services.AddSingleton(applicationSettings);
#endregion

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

#region Configure Shared Kernel
builder.Services.ConfigureCoreInfrastructure(applicationSettings);
#endregion

#region Configure Dotnet CAP
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IReportSubscriber, ReportConsumer>();

builder.Services.AddCap(cap =>
{
    cap.FailedRetryCount = 100;

    cap.UseDashboard();

    cap.UseSqlServer(applicationSettings.CapSettings.ReportQueueSettings.ConnectionStrings);

    cap.UseRabbitMQ(options =>
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
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IReportSubscriber, ReportConsumer>(c =>
{
    c.Timeout = TimeSpan.FromMilliseconds(5000);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
