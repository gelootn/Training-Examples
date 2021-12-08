using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.BLL.Infrastructure.Exceptions;
using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.EditCompany
{
    internal class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, EditCompanyCommandResponse>
    {
        private readonly IGenericRepository<Company> _repository;

        public EditCompanyCommandHandler(IGenericRepository<Company> repository)
        {
            _repository = repository;
        }
        public async Task<EditCompanyCommandResponse> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.FindAsync(x => x.Id == request.Id);

            if (company != null) { 
                company.Name = request.Name;
                company.Floor = request.Floor;
                company.PhoneNumber = request.PhoneNumber;
                company.Building = request.Building;
                company.VatNumber = request.VatNumber;

                await _repository.AddOrUpdate(company);

                return new EditCompanyCommandResponse { Id = company.Id };
            }

            throw new ItemNotFoundException(request.Id);
            
        }
    }
}
