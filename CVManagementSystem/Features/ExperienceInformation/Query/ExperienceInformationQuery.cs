using CVManagementSystem.Dto;
using MediatR;

namespace CVManagementSystem.Features.ExperienceInformation.Query
{
    public sealed record CreatExperienceInformationQuery(ExperienceInformationDto model) : IRequest<int>;
    public sealed record GetSinglExperienceInformationQuery(int id) : IRequest<ExperienceInformationDto>;
    public sealed record UpdatExperienceInformationQuery(ExperienceInformationDto model) : IRequest<int>;
}
