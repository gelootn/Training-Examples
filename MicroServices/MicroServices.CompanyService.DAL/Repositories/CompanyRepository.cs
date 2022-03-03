using MicroServices.CompanyService.DAL.Database;
using MicroServices.CompanyService.DAL.Models;
using MicroServices.CompanyService.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.CompanyService.DAL.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyServiceDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Company>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ICollection<Company>> GetAllWithEmployeesAsync()
        {
            return await DbSet.Include(c => c.Employees).ToListAsync();
        }

        public async Task<Company> GetAsync(int id)
        {
            return await DbSet.Include(c => c.Employees).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
