using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.DeleteCompany
{
    internal class DeleteCompanyCommandHandler : AsyncRequestHandler<DeleteCompanyCommand>
    {
        private readonly IGenericRepository<Company> _repository;

        public DeleteCompanyCommandHandler(IGenericRepository<Company> repository)
        {
            _repository = repository;
        }
        protected override async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.FindAsync(c => c.Id == request.Id);
            if (company == null)
                throw new ItemNotFoundException(request.Id);

            await _repository.Delete(company);
        }
    }
}
