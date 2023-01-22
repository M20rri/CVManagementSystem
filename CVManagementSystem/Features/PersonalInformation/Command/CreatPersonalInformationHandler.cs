using CVManagementSystem.Exceptions;
using CVManagementSystem.Features.PersonalInformation.Query;
using CVManagementSystem.Interface;
using CVManagementSystem.Validations;
using MediatR;
using System.Net;

namespace CVManagementSystem.Features.PersonalInformation.Command
{
    public sealed class CreatPersonalInformationHandler : IRequestHandler<CreatPersonalInformationQuery, int>
    {
        private readonly IPersonalInformation _repo;

        public CreatPersonalInformationHandler(IPersonalInformation repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreatPersonalInformationQuery request, CancellationToken cancellationToken)
        {
            PersonalInformationValidator validationRules = new PersonalInformationValidator();
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
