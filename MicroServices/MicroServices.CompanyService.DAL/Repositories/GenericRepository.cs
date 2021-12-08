using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.DAL.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MicroServices.CompanyService.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        internal DbSet<TEntity> DbSet { get; }

        private readonly CompanyServiceDbContext _context;

        public GenericRepository(CompanyServiceDbContext context)
        {

            DbSet = context.Set<TEntity>();
            _context = context;
        }
        public async Task AddOrUpdate(TEntity entity)
        {
            if (entity.Id == 0)
            {
                await DbSet.AddAsync(entity);
            }
            else
            {
                DbSet.Update(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entity.Deleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.FirstOrDefaultAsync(predicate);

    }
}
