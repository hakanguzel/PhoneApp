using PhoneApp.Core.Infrastructure;
using PhoneApp.Core.Infrastructure.Environments;
using PhoneApp.Core.Infrastructure.Middlewares;
using PhoneApp.UserService.Application;
using PhoneApp.UserService.Infrastructure;

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
builder.Services.AddUserServiceApplication();
builder.Services.AddUserServiceInfrastructure();
#endregion




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
