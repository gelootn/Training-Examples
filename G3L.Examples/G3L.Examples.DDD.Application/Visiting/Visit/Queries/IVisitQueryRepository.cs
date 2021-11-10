using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Interfaces;
using G3L.Examples.DDD.Application.Visiting.Visit.Queries.Common;
using G3L.Examples.DDD.Application.Visiting.Visit.Queries.Search;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries
{
    public interface IVisitQueryRepository : IQueryRepository<Domain.Visiting.Models.Visit>
    {
        Task<IEnumerable<VisitOutputModel>> GetOpenVisits(CancellationToken cancellationToken);
        Task<IEnumerable<VisitOutputModel>> GetVisits(VisitQuery searchParameters, CancellationToken cancellationToken);
    }
}