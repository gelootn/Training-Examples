using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.CompanyService.BLL.Models
{
    internal record Employee
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
