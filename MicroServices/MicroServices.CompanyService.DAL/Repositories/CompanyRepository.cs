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

        public async Task<ICollection<Company>> GetAll()
        {
            return await DbSet.Include(c=> c.Employees).ToListAsync();
        }
    }
}
