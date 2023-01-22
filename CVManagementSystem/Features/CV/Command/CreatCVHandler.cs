using CVManagementSystem.Features.CV.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.CV.Command
{
    public sealed class CreatCVHandler : IRequestHandler<CreatCVQuery, int>
    {
        private readonly ICV _repo;
        public CreatCVHandler(ICV repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(CreatCVQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Insert(request.model);
        }
    }
}
