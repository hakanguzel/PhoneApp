using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.UserService.Application.Users.Commands.DeleteContact
{
    public class DeleteContactCommand : ICommand<DeleteContactCommandResponse>
    {
        public DeleteContactCommand(int contactId)
        {
            ContactId = contactId;
        }
        public int ContactId { get; private set; }
    }

    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty().WithMessage("İletişim kimliği alanı boş bırakılamaz.")
            .GreaterThan(x => 0).WithMessage("İletişim kimliği sıfırdan büyük olmalıdır.");
        }
    }
}
