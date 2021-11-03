using G3L.Examples.DDD.Application.Common.Models;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Delete
{
    public class DeleteEmployeeCommand : EntityCommand<int>, IRequest<Result>
    {
        
    }
}