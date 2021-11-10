using G3L.Examples.DDD.Application.Visiting.Visit.Queries.Common;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries.Search
{
    public class VisitQuery : IRequest<VisitQueryOutputModel>
    {
        public string VisitorName { get; set; }
        public string VisitorEmail { get; set; }
        public string VisitorCompany { get; set; }
        public string Company { get; set; }
        public string Employee { get; set; }
    }
}