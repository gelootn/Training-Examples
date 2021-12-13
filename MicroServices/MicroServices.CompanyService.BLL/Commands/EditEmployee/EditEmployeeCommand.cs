using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Commands.EditEmployee
{
    public class EditEmployeeCommand : IRequest<EditEmployeeCommandResponse>
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
