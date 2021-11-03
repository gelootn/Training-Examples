using System.Collections.Generic;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Application.Companies.Company.Queries.Common;

namespace G3L.Examples.DDD.Application.Companies.Company.Queries.Search
{
    public class SearchCompanyOutputModel : PagedOutputModel<CompanyOutputModel>
    {
        public SearchCompanyOutputModel(IEnumerable<CompanyOutputModel> companies, int page, int totalPages) : base(companies, page, totalPages)
        {
        }
    }
}