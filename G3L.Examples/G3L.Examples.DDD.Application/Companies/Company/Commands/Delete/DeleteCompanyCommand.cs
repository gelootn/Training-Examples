using G3L.Examples.DDD.Application.Common.Models;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Delete
{
    public class DeleteCompanyCommand : EntityCommand<int>, IRequest<Result>
    {
    }
}