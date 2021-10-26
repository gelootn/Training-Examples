using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using G3L.Examples.NTier.BLL.Models.Company;
using G3L.Examples.NTier.BLL.Models.Employee;
using G3L.Examples.NTier.DAL.Entities;
using G3L.Examples.NTier.DAL.Repository;
using G3L.Examples.NTier.Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace G3L.Examples.NTier.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IAsyncGenericRepository<Company> _companyRepo;
        private readonly IAsyncGenericRepository<Employee> _employeeRepo;
        private readonly IMapper _mapper;

        public CompanyService(IAsyncGenericRepository<Company> companyRepo, IAsyncGenericRepository<Employee> employeeRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<Response<CompanyModel>> Get()
        {
            var result = await _companyRepo.GetAsync(null, q => 
                q.Include(x=> x.Employees.Where(x=> !x.Deleted)));
            
            var mapped = result.Select(x => _mapper.Map<CompanyModel>(x)).ToList();

            return new Response<CompanyModel>(mapped);
        }

        public async Task AddEmployeeToCompany(EmployeeModel employee, int companyId)
        {
            var c = await _companyRepo.FirstOrDefaultAsync(x => x.Id == companyId);
            var e = await _employeeRepo.FirstOrDefaultAsync(x => x.Id == employee.Id);
            
            c.Employees.Add(e);
            await _companyRepo.AddOrUpdateAsync(c);
            await _companyRepo.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            var e = await _employeeRepo.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (e != null)
            {
                e.CompanyId = employee.CompanyId;
                e.Email = employee.Email;
                e.Name = employee.Name;

                await _employeeRepo.AddOrUpdateAsync(e);
                await _employeeRepo.SaveChangesAsync();
            }
        }

        public async Task RemoveEmployee(EmployeeModel employee)
        {
            await _employeeRepo.Delete(employee.CompanyId);
            await _employeeRepo.SaveChangesAsync();
        }

        public async void Add(CompanyModel company)
        {
            var model = _mapper.Map<Company>(company);
            await _companyRepo.AddOrUpdateAsync(model);
            await _companyRepo.SaveChangesAsync();
        }
        
        public async void Update(CompanyModel company)
        {
            var model = _mapper.Map<Company>(company);
            await _companyRepo.AddOrUpdateAsync(model);
            await _companyRepo.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            _companyRepo.Delete(id);
            _companyRepo.SaveChangesAsync();
        }
    }
}