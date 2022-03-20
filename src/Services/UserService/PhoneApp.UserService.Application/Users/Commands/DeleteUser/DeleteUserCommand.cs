using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.UserService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : ICommand<DeleteUserCommandResponse>
    {
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; private set; }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı kimliği alanı boş bırakılamaz.")
            .GreaterThan(x => 0).WithMessage("Kullanıcı kimliği sıfırdan büyük olmalıdır.");
        }
    }
}
