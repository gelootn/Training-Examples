using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using G3L.Examples.NTier.DAL.Database;
using G3L.Examples.NTier.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace G3L.Examples.NTier.DAL.Repository
{
    public class AsyncGenericRepository<TEntity> : IAsyncGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly NTierDbContext _context;
        private readonly DbSet<TEntity> _set;

        public AsyncGenericRepository(NTierDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await GetAsync(null, null);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicates)
        {
            return await GetAsync(predicates, null);
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = _set.Where(x => !x.Deleted);
            if (predicates != null)
                query = query.Where(predicates);
            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicates)
        {
            return await FirstOrDefaultAsync(predicates, null);
        }
        
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = _set.Where(x => !x.Deleted);
            if (predicates != null)
                query = query.Where(predicates);
            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> AddOrUpdateAsync(TEntity entity)
        {
            if (entity.Id == 0)
            {
                await _set.AddAsync(entity);
            }
            else
            {
                _set.Update(entity);
            }

            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                entity.Deleted = true;
            }
        }

        public async Task Delete(int id)
        {
            var entity = await FirstOrDefaultAsync(x => x.Id == id);
            Delete(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}