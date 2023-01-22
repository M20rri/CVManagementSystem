using CVManagementSystem.Features.CV.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.CV.Command
{
    public sealed class UpdatCVHandler : IRequestHandler<UpdatCVQuery, int>
    {
        private readonly ICV _repo;
        public UpdatCVHandler(ICV repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(UpdatCVQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request.model);
        }
    }
}
