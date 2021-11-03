using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Visiting.Models;

namespace G3L.Examples.DDD.Domain.Visiting.Repositories
{
    public interface IVisitDomainRepository : IDomainRepository<Visit>
    {
        Task<Visit> FindByVisitor(string email, CancellationToken cancellationToken = default);
    }
}