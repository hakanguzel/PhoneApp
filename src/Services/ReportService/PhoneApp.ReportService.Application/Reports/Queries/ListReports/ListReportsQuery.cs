using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Application.Reports.Queries.ListReports
{
    public class ListReportsQuery : IQuery<ListReportsQueryResponse>
    {
    }

    public class ListReportsQueryValidator : AbstractValidator<ListReportsQuery>
    {
        public ListReportsQueryValidator()
        {
        }
    }
}
