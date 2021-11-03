using G3L.Examples.DDD.Application.Common.Models;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.AddEmployee
{
    public class AddEmployeeToCompanyCommand : IRequest<Result>
    {
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public int CompanyId { get; set; }
    }
}