using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.AddCompany
{
    internal class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, AddCompanyResponse>
    {
        private readonly IGenericRepository<Company> _repository;

        public AddCompanyCommandHandler(IGenericRepository<Company> repository)
        {
            _repository = repository;
        }
        public async Task<AddCompanyResponse> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                Name = request.Name,
                Building = request.Building,
                Floor = request.Floor,
                PhoneNumber = request.PhoneNumber,
                VatNumber = request.VatNumber
            };

            await _repository.AddOrUpdate(company);

            return new AddCompanyResponse { Id = company.Id };
        }
    }
}
