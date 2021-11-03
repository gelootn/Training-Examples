using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Search
{
    public class SearchCompanyQuery : IRequest<SearchCompanyOutputModel>
    {
        public string Name { get; set; }
    }
}