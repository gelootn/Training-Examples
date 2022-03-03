using MicroServices.Common.BLL.Commands;
using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.DeleteCompany
{
    internal class DeleteCompanyCommandHandler : DeleteCommandHandler<DeleteCompanyCommand, Company>
    {
        public DeleteCompanyCommandHandler(IGenericRepository<Company> repo) : base(repo)
        {
        }
    }
}
