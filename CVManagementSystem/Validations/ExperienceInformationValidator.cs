using CVManagementSystem.Dto;
using FluentValidation;

namespace CVManagementSystem.Validations
{
    public class ExperienceInformationValidator : AbstractValidator<ExperienceInformationDto>
    {
        public ExperienceInformationValidator()
        {
            RuleFor(x => x.CompanyName).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Company Name is required")
                .MaximumLength(20).WithMessage("Maximum length is 20 charachter");
        }
    }
}
