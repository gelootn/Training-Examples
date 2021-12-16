using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.DAL.Repositories.Contracts
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<ICollection<Company>> GetAllAsync();
        Task<ICollection<Company>> GetAllWithEmployeesAsync();
        Task<Company> GetAsync(int id);
    }
}
