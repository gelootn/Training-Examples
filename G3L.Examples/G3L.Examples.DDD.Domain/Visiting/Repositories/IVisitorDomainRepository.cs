using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Visiting.Models;

namespace G3L.Examples.DDD.Domain.Visiting.Repositories
{
    public interface IVisitorDomainRepository : IDomainRepository<Visitor>
    {
        Task<Visitor> FindByEmail(string email, CancellationToken cancellationToken = default);
    }
}