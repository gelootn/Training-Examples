using System.Threading;
using System.Threading.Tasks;

namespace G3L.Examples.DDD.Domain.Common.Interfaces
{
    public interface IDomainRepository<in TEntity> where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}