using CVManagementSystem.Dto;
using CVManagementSystem.Features.PersonalInformation.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.PersonalInformation.Command
{
    public sealed class GetSinglPersonalInformationHandler : IRequestHandler<GetSinglPersonalInformationQuery, PersonalInformationDto>
    {
        private readonly IPersonalInformation _repo;

        public GetSinglPersonalInformationHandler(IPersonalInformation repo)
        {
            _repo = repo;
        }

        public async Task<PersonalInformationDto> Handle(GetSinglPersonalInformationQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request.id);
        }
    }
}
