using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Application.Companies.Company.Commands.Common;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Edit
{
    public class EditCompanyCommand : CompanyCommand<EditCompanyCommand>, IRequest<Result>
    {
        
    }
}