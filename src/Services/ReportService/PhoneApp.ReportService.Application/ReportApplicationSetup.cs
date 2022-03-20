using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneApp.ReportService.Application.Reports.Commands.CreateReportRequest;
using PhoneApp.ReportService.Application.Reports.Commands.GenerateReport;
using PhoneApp.ReportService.Application.Reports.Queries.GetReport;
using PhoneApp.ReportService.Application.Reports.Queries.ListReports;
using System.Reflection;

namespace PhoneApp.ReportService.Application
{
    public static class ReportApplicationSetup
    {
        public static IServiceCollection AddReportServiceApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateReportRequestCommand).GetTypeInfo().Assembly);

            #region Validators

            #region Reports Validators
            services.AddTransient<IValidator<CreateReportRequestCommand>, CreateReportRequestCommandValidator>();
            services.AddTransient<IValidator<GenerateReportCommand>, GenerateReportCommandValidator>();
            services.AddTransient<IValidator<GetReportQuery>, GetReportQueryValidator>();
            services.AddTransient<IValidator<ListReportsQuery>, ListReportsQueryValidator>();
            #endregion

            #endregion

            return services;
        }
    }
}
