using CVManagementSystem.Exceptions;
using CVManagementSystem.Features.ExperienceInformation.Query;
using CVManagementSystem.Interface;
using CVManagementSystem.Validations;
using MediatR;
using System.Net;

namespace CVManagementSystem.Features.ExperienceInformation.Command
{
    public class CreatExperienceInformationHandler : IRequestHandler<CreatExperienceInformationQuery, int>
    {
        private readonly IExperienceInformation _repo;
        public CreatExperienceInformationHandler(IExperienceInformation repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CreatExperienceInformationQuery request, CancellationToken cancellationToken)
        {
            ExperienceInformationValidator validationRules = new ExperienceInformationValidator();
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            return await _repo.Insert(request.model);
        }
    }
}
