using FluentValidation;

namespace MicroServices.CompanyService.BLL.Commands.AddEmployee;

internal class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeCommandValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty();
        RuleFor(e => e.LastName).NotEmpty();
        RuleFor(e => e.Email).NotEmpty().EmailAddress();
        RuleFor(e => e.CompanyId).GreaterThan(0);
    }
}