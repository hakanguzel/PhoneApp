using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.ReportService.Application.Reports.Commands.CreateReportRequest
{
    public class CreateReportRequestCommand : ICommand<CreateReportRequestCommandResponse>
    {
        public string Location { get; set; }
    }

    public class CreateReportRequestCommandValidator : AbstractValidator<CreateReportRequestCommand>
    {
        public CreateReportRequestCommandValidator()
        {
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Lokasyon alanı boş bırakılamaz.");
        }
    }
}
