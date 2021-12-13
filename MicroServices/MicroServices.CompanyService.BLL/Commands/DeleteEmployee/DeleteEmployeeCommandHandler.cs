using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.DAL.Models;
using MicroServices.Common.BLL.Commands;

namespace MicroServices.CompanyService.BLL.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandHandler : DeleteCommandHandler<DeleteEmployeeCommand, Employee>
    {
        public DeleteEmployeeCommandHandler(IGenericRepository<Employee> repo) : base(repo)
        {
        }
    }
}
