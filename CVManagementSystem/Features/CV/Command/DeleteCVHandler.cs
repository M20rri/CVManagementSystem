using CVManagementSystem.Features.CV.Query;
using CVManagementSystem.Interface;
using MediatR;

namespace CVManagementSystem.Features.CV.Command
{
    public sealed class DeleteCVHandler : IRequestHandler<DeleteCVQuery, int>
    {
        private readonly ICV _repo;
        public DeleteCVHandler(ICV repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(DeleteCVQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request.id);
        }
    }
}
