using CVManagementSystem.Dto;
using MediatR;

namespace CVManagementSystem.Features.PersonalInformation.Query
{
    public sealed record CreatPersonalInformationQuery(PersonalInformationDto model) : IRequest<int>;
    public sealed record GetSinglPersonalInformationQuery(int id) : IRequest<PersonalInformationDto>;
    public sealed record UpdatPersonalInformationQuery(PersonalInformationDto model) : IRequest<int>;
}
