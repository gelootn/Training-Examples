using System.Collections.Generic;
using System.Threading.Tasks;
using G3L.Examples.NTier.BLL.Models.Company;
using G3L.Examples.NTier.BLL.Models.Employee;
using G3L.Examples.NTier.Framework.Models;

namespace G3L.Examples.NTier.BLL.Services
{
    public interface ICompanyService
    {
        Task<Response<CompanyModel>> Get();
        Task AddEmployeeToCompany(EmployeeModel employee, int companyId);
        Task UpdateEmployee(EmployeeModel employee);
        Task RemoveEmployee(EmployeeModel employee);
        void Add(CompanyModel company);
        void Update(CompanyModel company);
        void Delete(int id);
    }
}