using FluentValidation;
using G3L.Examples.DDD.Application.Companies.Employee.Commands.Common;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Edit
{
    public class EditEmployeeCommandValidator : AbstractValidator<EditEmployeeCommand>
    {
        public EditEmployeeCommandValidator()
        {
            Include(new EmployeeCommandValidator<EditEmployeeCommand>());
        }
    }
}