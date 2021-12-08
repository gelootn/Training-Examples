using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandHandler : AsyncRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IGenericRepository<Employee> _repository;

        public DeleteEmployeeCommandHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }
        protected override async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.FindAsync(e => e.Id == request.Id);
            if (employee == null)
                throw new ItemNotFoundException(request.Id);


            await _repository.Delete(employee);
        }
    }
}
