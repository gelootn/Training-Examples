using MicroServices.CompanyService.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<ICollection<Company>>
    {

    }
}
