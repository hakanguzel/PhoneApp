using FluentValidation;
using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.UserService.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IQuery<GetUserQueryResponse>
    {
        public GetUserQuery(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; private set; }
    }
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı kimliği alanı boş bırakılamaz.")
            .GreaterThan(x => 0).WithMessage("Kullanıcı kimliği sıfırdan büyük olmalıdır.");
        }
    }
}
