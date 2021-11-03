using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Companies.Models;

namespace G3L.Examples.DDD.Domain.Companies.Repositories
{
    public interface IEmployeeDomainRepository : IDomainRepository<Employee>
    {
        Task<Employee> Find(int id, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}