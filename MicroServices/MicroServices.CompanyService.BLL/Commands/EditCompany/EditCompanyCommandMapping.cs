using AutoMapper;
using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.EditCompany
{
    internal class EditCompanyCommandMapping : Profile
    {
        public EditCompanyCommandMapping()
        {
            CreateMap<EditCompanyCommand, Company>();
        }
    }
}
