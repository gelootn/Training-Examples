using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using G3L.Examples.NTier.DAL.Entities;

namespace G3L.Examples.NTier.DAL.Repository;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> Get();
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicates);
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicates);
    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

    TEntity AddOrUpdate(TEntity entity);
    void Delete(TEntity entity);
    void Delete(int id);

    void SaveChanges();

}
