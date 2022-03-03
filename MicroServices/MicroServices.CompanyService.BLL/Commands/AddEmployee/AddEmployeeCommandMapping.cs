using MicroServices.CompanyService.DAL.Models;

namespace MicroServices.CompanyService.BLL.Commands.AddEmployee;

internal class AddEmployeeCommandMapping : Profile
{
    public AddEmployeeCommandMapping()
    {
        CreateMap<AddEmployeeCommand, Employee>();
    }
}