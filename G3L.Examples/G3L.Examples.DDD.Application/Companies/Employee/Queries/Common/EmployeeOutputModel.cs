using AutoMapper;
using G3L.Examples.DDD.Application.Common.Interfaces;

namespace G3L.Examples.DDD.Application.Companies.Employee.Queries.Common
{
    public class EmployeeOutputModel : IMapFrom<Domain.Companies.Models.Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}