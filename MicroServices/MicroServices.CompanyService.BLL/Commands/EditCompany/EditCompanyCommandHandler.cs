using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.EditCompany;

internal class EditCompanyCommandHandler : EditCommandHandler<EditCompanyCommand, Company, EditCompanyCommandResponse>
{
    public EditCompanyCommandHandler(IGenericRepository<Company> repo, IMapper mapper) : base(repo, mapper)
    {
    }
}