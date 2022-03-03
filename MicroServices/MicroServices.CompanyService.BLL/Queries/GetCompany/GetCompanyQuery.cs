using MicroServices.CompanyService.BLL.Models;

namespace MicroServices.CompanyService.BLL.Queries.GetCompany;

public class GetCompanyQuery : IRequest<Company>
{
    public int Id { get; set; }
}