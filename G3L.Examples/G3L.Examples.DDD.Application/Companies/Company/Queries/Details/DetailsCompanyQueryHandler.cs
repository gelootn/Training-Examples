using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Details
{
    public class DetailsCompanyQueryHandler : IRequestHandler<DetailsCompanyQuery, DetailsCompanyOutputModel>
    {
        private readonly ICompanyQueryRepository _repository;

        public DetailsCompanyQueryHandler(ICompanyQueryRepository repository)
        {
            _repository = repository;
        }
        public Task<DetailsCompanyOutputModel> Handle(DetailsCompanyQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}