using MicroServices.Common.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.EditEmployee
{
    internal class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, EditEmployeeCommandResponse>
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IGenericRepository<Company> _companyRepository;

        public EditEmployeeCommandHandler(IGenericRepository<Employee> repository, IGenericRepository<Company> companyRepository)
        {
            _repository = repository;
            _companyRepository = companyRepository;
        }
        public async Task<EditEmployeeCommandResponse> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.FindAsync(e => e.Id == request.EmployeeId);

            if (employee == null)
                throw new ItemNotFoundException(request.EmployeeId, typeof(Employee));

            var company = await _companyRepository.FindAsync(c => c.Id == request.CompanyId);
            if (company == null)
                throw new ItemNotFoundException(request.CompanyId, typeof(Company));

            employee.Company = company;
            employee.Name = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;

            await _repository.AddOrUpdate(employee);

            return new EditEmployeeCommandResponse { Id = employee.Id};
        }
    }
}
