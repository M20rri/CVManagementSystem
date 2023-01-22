using CVManagementSystem.Dto;
using FluentValidation;

namespace CVManagementSystem.Validations
{
    public class CVValidator : AbstractValidator<CVDtoPage>
    {
        public CVValidator()
        {

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(x => "CV Name is required");

            RuleFor(x => x.Experience_Information.CompanyName).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Company Name is required")
               .MaximumLength(20).WithMessage("Company Name Maximum length is 20 charachter");

            RuleFor(x => x.Personal_Information.Fullname).NotNull().NotEmpty().WithMessage(x => "FullName is required");
            RuleFor(x => x.Personal_Information.Email).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Personal_Information.Mobile).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Mobile is required")
                .Matches(@"^[0-9]*\.?[0-9]+$").WithMessage("Invalid mobile number");
        }
    }
}
