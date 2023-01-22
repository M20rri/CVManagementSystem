using CVManagementSystem.Dto;
using FluentValidation;

namespace CVManagementSystem.Validations
{
    public class PersonalInformationValidator : AbstractValidator<PersonalInformationDto>
    {
        public PersonalInformationValidator()
        {
            RuleFor(x => x.Fullname).NotNull().NotEmpty().WithMessage(x => "FullName is required");
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Mobile).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Mobile is required")
                .Matches(@"^[0-9]*\.?[0-9]+$").WithMessage("Invalid mobile number");
        }
    }
}
