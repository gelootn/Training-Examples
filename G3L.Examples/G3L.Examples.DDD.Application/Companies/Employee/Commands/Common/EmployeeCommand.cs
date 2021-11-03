using G3L.Examples.DDD.Application.Common.Models;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Common
{
    public abstract class EmployeeCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
    }
}