using PhoneApp.Core.Infrastructure;
using PhoneApp.Core.Infrastructure.Environments;
using PhoneApp.Core.Infrastructure.Middlewares;
using PhoneApp.ReportService.Application;
using PhoneApp.ReportService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//---Services-Related Configurations---//
var _applicationSettings = new ApplicationSettings();

builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

#region Settings
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
builder.Configuration.GetSection("ApplicationSettings").Bind(_applicationSettings);
#endregion

#region Core Setup
builder.Services.ConfigureCoreInfrastructure(_applicationSettings);
#endregion

#region User Setup
builder.Services.AddReportServiceApplication();
builder.Services.AddReportServiceInfrastructure();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseExceptionHandler("/error");

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
