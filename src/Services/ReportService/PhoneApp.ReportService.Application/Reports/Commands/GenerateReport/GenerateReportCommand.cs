using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Application.Reports.Commands.GenerateReport
{
    public class GenerateReportCommand : ICommand<GenerateReportCommandResponse>
    {
        public int ReportId { get; set; }
    }
    public class GenerateReportCommandValidator : AbstractValidator<GenerateReportCommand>
    {
        public GenerateReportCommandValidator()
        {
            RuleFor(x => x.ReportId)
                .NotEmpty().WithMessage("Rapor id alanı boş bırakılamaz.");
        }
    }
}
