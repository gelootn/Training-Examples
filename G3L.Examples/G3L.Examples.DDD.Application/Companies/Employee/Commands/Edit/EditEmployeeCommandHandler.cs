using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Edit
{
    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand,Result>
    {
        private readonly IEmployeeDomainRepository _repository;

        public EditEmployeeCommandHandler(IEmployeeDomainRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Result> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.Find(request.Id, cancellationToken);

            employee.UpdateName(request.Name);
            employee.UpdateEmail(request.Email);

            await _repository.Save(employee, cancellationToken);
            
            return Result.Success;
        }
    }
}