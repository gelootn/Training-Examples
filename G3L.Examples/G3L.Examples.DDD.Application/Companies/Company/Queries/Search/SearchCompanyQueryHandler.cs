using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Search
{
    public class SearchCompanyQueryHandler : IRequestHandler<SearchCompanyQuery, SearchCompanyOutputModel>
    {
        private readonly ICompanyQueryRepository _repository;

        public SearchCompanyQueryHandler(ICompanyQueryRepository repository)
        {
            _repository = repository;
        }
        public Task<SearchCompanyOutputModel> Handle(SearchCompanyQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
} 