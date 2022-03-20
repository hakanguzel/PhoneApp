using PhoneApp.Core.Application.Abstractions;
using FluentValidation;

namespace PhoneApp.UserService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICommand<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Firma alanı boş bırakılamaz.");
        }
    }
}
