using System;
using System.Linq;
using System.Linq.Expressions;
using G3L.Examples.NTier.DAL.Database;
using G3L.Examples.NTier.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace G3L.Examples.NTier.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly NTierDbContext _context;
        private readonly DbSet<TEntity> _set;

        public GenericRepository(NTierDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> Get()
        {
            return Get(null, null);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicates)
        {
            return Get(predicates, null);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = _set.Where(x => !x.Deleted);

            if (predicates != null)
                query = query.Where(predicates);

            if (include != null)
                query = include(query);

            return query;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicates)
        {
            return FirstOrDefault(predicates, null);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicates, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = _set.Where(x => !x.Deleted).Where(predicates);
            
            if(include != null)
                query = include(query);

            return query.FirstOrDefault();

        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            if (entity.Id == 0)
            {
                _set.Add(entity);
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
                _set.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = FirstOrDefault(x => x.Id == id);
            Delete(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}