using G3L.Examples.DDD.Domain.Common.Interfaces;

namespace G3L.Examples.DDD.Application.Common.Interfaces
{
    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot 
    {
    }
}