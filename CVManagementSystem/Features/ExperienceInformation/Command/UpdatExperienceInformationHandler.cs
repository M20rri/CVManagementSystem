using CVManagementSystem.Exceptions;
using CVManagementSystem.Features.ExperienceInformation.Query;
using CVManagementSystem.Interface;
using CVManagementSystem.Validations;
using MediatR;
using System.Net;

namespace CVManagementSystem.Features.ExperienceInformation.Command
{
    public class UpdatExperienceInformationHandler : IRequestHandler<UpdatExperienceInformationQuery, int>
    {
        private readonly IExperienceInformation _repo;
        public UpdatExperienceInformationHandler(IExperienceInformation repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdatExperienceInformationQuery request, CancellationToken cancellationToken)
        {
            ExperienceInformationValidator validationRules = new ExperienceInformationValidator();
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            return await _repo.Update(request.model);
        }
    }
}
