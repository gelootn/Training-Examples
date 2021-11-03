using G3L.Examples.DDD.Application.Common.Models;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Commands.Register
{
    public class RegisterVisitCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
    }
}