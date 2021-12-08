
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.AddCompany
{
    public record AddCompanyCommand : IRequest<AddCompanyResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VatNumber { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
    }

    internal class AddCompanyResponse
    {
        public int Id { get; set; }
    }
}
