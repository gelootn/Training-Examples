using MediatR;
using MicroServices.CompanyService.API.Models;
using MicroServices.CompanyService.BLL.Commands.AddCompany;
using MicroServices.CompanyService.BLL.Commands.AddEmployee;
using MicroServices.CompanyService.BLL.Commands.DeleteCompany;
using MicroServices.CompanyService.BLL.Commands.DeleteEmployee;
using MicroServices.CompanyService.BLL.Commands.EditCompany;
using MicroServices.CompanyService.BLL.Commands.EditEmployee;
using MicroServices.CompanyService.BLL.Queries.GetCompanies;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.CompanyService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCompaniesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyModel model)
        {
            var command = new AddCompanyCommand
            {
                Name = model.Name,
                Building = model.Building,
                Floor = model.Floor,
                PhoneNumber = model.PhoneNumber,
                VatNumber = model.VatNumber
            };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, CompanyModel model)
        {
            var command = new EditCompanyCommand
            {
                Id = id,
                Name = model.Name,
                Building = model.Building,
                Floor = model.Floor,
                PhoneNumber = model.PhoneNumber,
                VatNumber = model.VatNumber
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteCompanyCommand
            {
                Id = id
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("{id}/employee")]
        public async Task<IActionResult> AddEmployeeToCompany([FromRoute] int id, EmployeeModel employee)
        {
            var command = new AddEmployeeCommand
            {
                CompanyId = id,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
            var result = await _mediator.Send(command);
            return Ok();
        }


        [HttpPut("{id}/employee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromRoute] int employeeId, EmployeeModel employee)
        {
            var command = new EditEmployeeCommand
            {
                EmployeeId = employeeId,
                CompanyId = id,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}/employee/{employeeId}")]
        public async Task<IActionResult> RemoveEmployee([FromRoute] int id, [FromRoute] int employeeId)
        {
            var command = new DeleteEmployeeCommand { Id = employeeId};
            await _mediator.Send(command);
            return Ok();
        }
    }
}
