using System.Threading.Tasks;

namespace G3L.Examples.NTier.BLL.Services;

public interface ICompanyService
{
    Task<Response<CompanyModel>> Get();
    Task AddEmployeeToCompany(EmployeeModel employee, int companyId);
    Task UpdateEmployee(EmployeeModel employee);
    Task RemoveEmployee(int id);
    Task Add(CompanyModel company);
    Task Update(CompanyModel company);
    Task Delete(int id);
}
