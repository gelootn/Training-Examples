using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.AddEmployee
{
    internal class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, AddEmployeeCommandResponse>
    {
        private readonly IGenericRepository<Company> _companyRepository;

        public AddEmployeeCommandHandler(IGenericRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.FindAsync(c => c.Id == request.CompanyId);
            if (company == null)
                throw new ItemNotFoundException(request.CompanyId);

            var employee = new Employee { 
                Name = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            company.Employees.Add(employee);
            await _companyRepository.AddOrUpdate(company);

            return new AddEmployeeCommandResponse { Id = employee.Id };
        }
    }
}
