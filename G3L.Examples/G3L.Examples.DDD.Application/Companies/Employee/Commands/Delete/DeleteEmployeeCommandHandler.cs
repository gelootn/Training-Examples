using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Delete
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result>
    {
        private readonly IEmployeeDomainRepository _repository;

        public DeleteEmployeeCommandHandler(IEmployeeDomainRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Delete(request.Id, cancellationToken);
        }
    }
}