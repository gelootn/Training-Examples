using MediatR;
using MicroServices.Common.BLL.Infrastructure.Exceptions;
using Microservices.Common.DAL.Contracts;
using Microservices.Common.DAL.Models;

namespace MicroServices.Common.BLL.Commands
{
    public class DeleteCommandHandler<TRequest, TModel> : AsyncRequestHandler<TRequest>
        where TRequest : DeleteCommand
        where TModel : Entity
    {
        private readonly IGenericRepository<TModel> _repo;

        public DeleteCommandHandler(IGenericRepository<TModel> repo)
        {
            _repo = repo;
        }

        protected override async Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(c => c.Id == request.Id);
            if (entity == null)
                throw new ItemNotFoundException(request.Id);

            await _repo.Delete(entity);
        }
    }
}
