using CVManagementSystem.Dto;
using CVManagementSystem.Features.CV.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.CV.Command
{
    public sealed class GetAllCVHandler : IRequestHandler<GetAllCVQuery, List<CVDto>>
    {
        private readonly ICV _repo;
        public GetAllCVHandler(ICV repo)
        {
            _repo = repo;
        }
        public async Task<List<CVDto>> Handle(GetAllCVQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
