using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Interfaces;
using G3L.Examples.DDD.Application.Companies.Company.Queries.Common;

namespace G3L.Examples.DDD.Application.Companies.Company
{
    public interface ICompanyQueryRepository : IQueryRepository<Domain.Companies.Models.Company>
    {
        Task<IEnumerable<CompanyOutputModel>> Search(string name, CancellationToken cancellationToken = default);
        
    }
}