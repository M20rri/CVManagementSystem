using CVManagementSystem.Dto;
using CVManagementSystem.Features.ExperienceInformation.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.ExperienceInformation.Command
{
    public class GetSinglExperienceInformationHandler : IRequestHandler<GetSinglExperienceInformationQuery, ExperienceInformationDto>
    {
        private readonly IExperienceInformation _repo;
        public GetSinglExperienceInformationHandler(IExperienceInformation repo)
        {
            _repo = repo;
        }
        public async Task<ExperienceInformationDto> Handle(GetSinglExperienceInformationQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request.id);
        }
    }
}
