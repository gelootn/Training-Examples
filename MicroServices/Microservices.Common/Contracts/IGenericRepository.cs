using Microservices.Common.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Microservices.Common.DAL.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddOrUpdate(TEntity entity);
        Task Delete(TEntity entity);        
    }
}
