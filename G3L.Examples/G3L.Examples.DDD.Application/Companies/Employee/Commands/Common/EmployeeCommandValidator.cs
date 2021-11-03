using FluentValidation;
using G3L.Examples.DDD.Application.Common.Models;
using static G3L.Examples.DDD.Domain.Common.ModelConstants;

namespace G3L.Examples.DDD.Application.Companies.Employee.Commands.Common
{
    public class EmployeeCommandValidator<TCommand> : AbstractValidator<EmployeeCommand<TCommand>> 
        where TCommand : EntityCommand<int>
    {
        public EmployeeCommandValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.CompanyId)
                .NotEmpty();
        }
    }
}