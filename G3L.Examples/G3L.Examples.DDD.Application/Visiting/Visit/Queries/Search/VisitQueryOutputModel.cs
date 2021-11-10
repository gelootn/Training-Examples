using System.Collections.Generic;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Application.Visiting.Visit.Queries.Common;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries.Search
{
    public class VisitQueryOutputModel : PagedOutputModel<VisitOutputModel>
    {
        internal VisitQueryOutputModel(IEnumerable<VisitOutputModel> companies, int page, int totalPages) : base(companies, page, totalPages)
        {
        }
    }
}