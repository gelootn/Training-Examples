using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.AddCompany;

public class AddCompanyCommandMapping : Profile
{
    public AddCompanyCommandMapping()
    {
        CreateMap<AddCompanyCommand, Company>();
    }
}