using FluentValidation;
using static G3L.Examples.DDD.Domain.Common.ModelConstants;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Commands.Register
{
    public class RegisterVisitCommandValidator : AbstractValidator<RegisterVisitCommand>
    {
        public RegisterVisitCommandValidator()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty();
            RuleFor(x => x.EmployeeId)
                .NotEmpty();
            
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
            RuleFor(x => x.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
            
            RuleFor(x => x.Company)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
        }
    }
}