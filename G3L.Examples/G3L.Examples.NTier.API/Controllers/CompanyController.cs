using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.NTier.BLL.Models.Company;
using G3L.Examples.NTier.BLL.Models.Employee;
using G3L.Examples.NTier.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace G3L.Examples.NTier.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.Get();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(CompanyModel model)
        {
            _service.Add(model);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, CompanyModel model)
        {
            _service.Update(model);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpPost("{id}/employee")]
        public async Task<IActionResult> AddEmployeeToCompany([FromRoute] int id,EmployeeModel employee)
        {
            await _service.AddEmployeeToCompany(employee, id);
            return Ok();
        }
        
        
        [HttpPut("{id}/employee")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id,EmployeeModel employee)
        {
            await _service.UpdateEmployee(employee);
            return Ok();
        }
        
        [HttpDelete("{id}/employee")]
        public async Task<IActionResult> RemoveEmployee([FromRoute] int id,EmployeeModel employee)
        {
            await _service.RemoveEmployee(employee);
            return Ok();
        }
    }
}