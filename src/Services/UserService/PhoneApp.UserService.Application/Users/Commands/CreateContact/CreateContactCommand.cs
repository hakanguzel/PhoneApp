using FluentValidation;
using PhoneApp.Core.Application.Abstractions;
using System.Text.Json.Serialization;

namespace PhoneApp.UserService.Application.Users.Commands.CreateContact
{
    public class CreateContactCommand : ICommand<CreateContactCommandResponse>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public List<Contact> Contact { get; set; }
    }
    public class Contact
    {
        public string InformationType { get; set; }
        public string Content { get; set; }
    }

    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı id alanı boş bırakılamaz.");

            RuleFor(x => x.Contact)
                .NotEmpty().WithMessage("İletişim alanı boş bırakılamaz. Lütfen en az bir İletişim bilgisi belirleyin.")
                .ChildRules(options =>
                {
                    options.RuleForEach(x => x.Select(q => q.InformationType))
                        .NotEmpty().WithMessage("InformationType alanı boş bırakılamaz.");
                    options.RuleForEach(x => x.Select(q => q.Content))
                        .NotEmpty().WithMessage("İçerik alanı boş bırakılamaz.");
                });

        }
    }
}
