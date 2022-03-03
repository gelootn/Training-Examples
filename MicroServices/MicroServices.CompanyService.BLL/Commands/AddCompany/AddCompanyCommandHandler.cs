using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.AddCompany;

internal class AddCompanyCommandHandler : AddCommandHandler<AddCompanyCommand, Company, AddCompanyCommandResponse>
{
    public AddCompanyCommandHandler(IGenericRepository<Company> repo, IMapper mapper) : base(repo, mapper)
    {
    }
}