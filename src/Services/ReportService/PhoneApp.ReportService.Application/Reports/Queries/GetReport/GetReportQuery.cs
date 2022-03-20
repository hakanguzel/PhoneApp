using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Application.Reports.Queries.GetReport
{
    public class GetReportQuery : IQuery<GetReportQueryResponse>
    {
        public GetReportQuery(int reportId)
        {
            ReportId = reportId;
        }
        public int ReportId { get; private set; }
    }

    public class GetReportQueryValidator : AbstractValidator<GetReportQuery>
    {
        public GetReportQueryValidator()
        {
            RuleFor(x => x.ReportId)
                .NotEmpty().WithMessage("Rapor id alanı boş bırakılamaz.");
        }
    }
}
