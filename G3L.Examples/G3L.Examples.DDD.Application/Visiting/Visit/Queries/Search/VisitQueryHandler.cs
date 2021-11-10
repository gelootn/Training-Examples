using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries.Search
{
    public class VisitQueryHandler : IRequestHandler<VisitQuery, VisitQueryOutputModel>
    {
        private readonly IVisitQueryRepository _repository;

        public VisitQueryHandler(IVisitQueryRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<VisitQueryOutputModel> Handle(VisitQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetVisits(request, cancellationToken);
            
            return new VisitQueryOutputModel(data, 0, 1) ;
        }
    }
}