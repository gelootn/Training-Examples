using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using G3L.Examples.NTier.DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace G3L.Examples.NTier.DAL.Repository
{
    public interface IAsyncGenericRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicates);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicates);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicates,Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        
        Task<TEntity> AddOrUpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);

        Task SaveChangesAsync();
    }
}