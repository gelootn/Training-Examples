using System.Collections.Generic;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Application.Visiting.Visit.Queries.Common;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Queries.Open
{
    public class OpenVisitOutputModel : PagedOutputModel<VisitOutputModel>
    {
        internal OpenVisitOutputModel(IEnumerable<VisitOutputModel> companies, int page, int totalPages) : base(companies, page, totalPages)
        {
        }
    }
}