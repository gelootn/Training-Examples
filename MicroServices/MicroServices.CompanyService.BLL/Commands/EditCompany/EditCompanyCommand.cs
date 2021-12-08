using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.EditCompany
{
    public class EditCompanyCommand : IRequest<EditCompanyCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VatNumber { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
    }

    internal class EditCompanyCommandResponse
    {
        public int Id { get; set; }
    }
}
