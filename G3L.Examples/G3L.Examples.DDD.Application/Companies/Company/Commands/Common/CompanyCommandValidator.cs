using FluentValidation;
using G3L.Examples.DDD.Application.Common.Models;
using static G3L.Examples.DDD.Domain.Common.ModelConstants;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Common
{
    public class CompanyCommandValidator<TCommand> : AbstractValidator<CompanyCommand<TCommand>> 
        where TCommand : EntityCommand<int>
    {
        public CompanyCommandValidator()
        {
            RuleFor(x => x.CompanyName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
        }
    }
}