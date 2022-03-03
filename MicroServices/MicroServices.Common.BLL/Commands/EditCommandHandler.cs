using AutoMapper;
using MediatR;
using MicroServices.Common.BLL.Infrastructure.Exceptions;
using Microservices.Common.DAL.Contracts;
using Microservices.Common.DAL.Models;

namespace MicroServices.Common.BLL.Commands
{
    public abstract class EditCommandHandler<TRequest, TModel, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : BaseCommand, IRequest<TResponse>
        where TResponse : BaseCommandResponse, new()
        where TModel : Entity
    {
        private readonly IGenericRepository<TModel> _repo;
        private readonly IMapper _mapper;

        public EditCommandHandler(IGenericRepository<TModel> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(x => x.Id == request.Id);

            if (entity == null) 
                throw new ItemNotFoundException(request.Id);


            _mapper.Map(request, entity);
            await _repo.AddOrUpdate(entity);

            return new TResponse { Id = entity.Id };

        }
    }
}
