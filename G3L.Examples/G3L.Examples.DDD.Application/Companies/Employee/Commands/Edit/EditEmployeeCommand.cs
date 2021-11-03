using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Application.Companies.Employee.Commands.Common;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Edit
{
    public class EditEmployeeCommand : EmployeeCommand<EditEmployeeCommand>, IRequest<Result>
    {
        
    }
}