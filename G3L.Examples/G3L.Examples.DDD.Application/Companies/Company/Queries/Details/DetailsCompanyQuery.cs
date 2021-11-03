using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Details
{
    public class DetailsCompanyQuery : IRequest<DetailsCompanyOutputModel>
    {
        public int Id { get; set; }
    }
}