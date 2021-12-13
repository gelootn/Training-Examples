using MicroServices.Common.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.AddEmployee
{
    internal class AddEmployeeCommandHandler : AddCommandHandler<AddEmployeeCommand, Employee, AddEmployeeCommandResponse>
    {
        private readonly IGenericRepository<Company> _companyRepository;

        public AddEmployeeCommandHandler(IGenericRepository<Employee> repo, IGenericRepository<Company> companyRepository, IMapper mapper) : base(repo, mapper)
        {
            _companyRepository = companyRepository;
        }

        public override async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.FindAsync(c => c.Id == request.CompanyId);
            if (company == null)
                throw new ItemNotFoundException(request.CompanyId);
            
            var employee = new Employee { 
                Name = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Company = company
            };
            
            await Repo.AddOrUpdate(employee);
            
            return new AddEmployeeCommandResponse { Id = employee.Id };
        }
    }
}
