namespace G3L.Examples.DDD.Domain.Common.Interfaces
{
    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}