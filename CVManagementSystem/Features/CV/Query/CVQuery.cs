using CVManagementSystem.Dto;
using MediatR;

namespace CVManagementSystem.Features.CV.Query
{
    public sealed record CreatCVQuery(CVDto model) : IRequest<int>;
    public sealed record GetSinglCVQuery(int id) : IRequest<CVDtoPage>;
    public sealed record GetAllCVQuery() : IRequest<List<CVDto>>;
    public sealed record UpdatCVQuery(CVDto model) : IRequest<int>;
    public sealed record DeleteCVQuery(int id) : IRequest<int>;
}
