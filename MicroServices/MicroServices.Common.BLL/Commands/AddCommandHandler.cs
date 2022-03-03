using AutoMapper;
using MediatR;
using Microservices.Common.DAL.Contracts;
using Microservices.Common.DAL.Models;

namespace MicroServices.Common.BLL.Commands
{
    public abstract class AddCommandHandler<TRequest, TModel, TResponse> : IRequestHandler<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse : BaseCommandResponse, new()
        where TModel : Entity
    {
        protected readonly IGenericRepository<TModel> Repo;
        private readonly IMapper _mapper;

        public AddCommandHandler(IGenericRepository<TModel> repo, IMapper mapper)
        {
            Repo = repo;
            _mapper = mapper;
        }
        public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TModel>(request);
            await Repo.AddOrUpdate(entity);
            return new TResponse{ Id = entity.Id };

        }

    }
}
