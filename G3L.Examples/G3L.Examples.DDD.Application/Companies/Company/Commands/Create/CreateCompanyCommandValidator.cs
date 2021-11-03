using FluentValidation;
using G3L.Examples.DDD.Application.Companies.Company.Commands.Common;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Create
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            Include(new CompanyCommandValidator<CreateCompanyCommand>());
        }
        
    }
}