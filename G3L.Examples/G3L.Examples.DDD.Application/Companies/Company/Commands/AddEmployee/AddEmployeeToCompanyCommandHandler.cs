using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Factories.Employee;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.AddEmployee
{
    public class AddEmployeeToCompanyCommandHandler : IRequestHandler<AddEmployeeToCompanyCommand, Result>
    {
        private readonly ICompanyDomainRepository _repository;
        private readonly IEmployeeFactory _employeeFactory;

        public AddEmployeeToCompanyCommandHandler(ICompanyDomainRepository repository, IEmployeeFactory employeeFactory)
        {
            _repository = repository;
            _employeeFactory = employeeFactory;
        }
        public async Task<Result> Handle(AddEmployeeToCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.Find(request.CompanyId, cancellationToken);

            if(company == null) return Result.Failure(new []{"Company not found"});
            
            var employee = _employeeFactory
                .WithName(request.EmployeeName)
                .WithEmail(request.EmployeeEmail)
                .Build();
            
            company.AddEmployee(employee);

            await _repository.Save(company, cancellationToken);
            
            return Result.Success;
        }
    }
}