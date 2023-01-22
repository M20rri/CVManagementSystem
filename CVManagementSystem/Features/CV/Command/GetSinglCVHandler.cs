using CVManagementSystem.Dto;
using CVManagementSystem.Features.CV.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.CV.Command
{
    public sealed class GetSinglCVHandler : IRequestHandler<GetSinglCVQuery, CVDtoPage>
    {
        private readonly ICV _repo;
        public GetSinglCVHandler(ICV repo)
        {
            _repo = repo;
        }
        public async Task<CVDtoPage> Handle(GetSinglCVQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request.id);
        }
    }
}
