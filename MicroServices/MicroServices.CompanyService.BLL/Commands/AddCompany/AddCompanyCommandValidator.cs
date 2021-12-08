using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.AddCompany
{
    internal class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
    {
        public AddCompanyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3);
            RuleFor(c => c.Building).NotEmpty();
            RuleFor(c => c.Floor).GreaterThanOrEqualTo(0);
            RuleFor(c => c.VatNumber).Matches("BE0[0-9]{9}");
        }
    }
}
