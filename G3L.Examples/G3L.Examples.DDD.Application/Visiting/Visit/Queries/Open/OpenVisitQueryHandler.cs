using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Visiting.Visit.Queries.Common;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries.Open
{
    public class OpenVisitQueryHandler : IRequestHandler<OpenVisitQuery, OpenVisitOutputModel>
    {
        private readonly IVisitQueryRepository _repository;

        public OpenVisitQueryHandler(IVisitQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<OpenVisitOutputModel> Handle(OpenVisitQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetOpenVisits(cancellationToken);
            return new OpenVisitOutputModel(data, 0, 1);
        } 
    }
}