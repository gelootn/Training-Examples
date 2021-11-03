using G3L.Examples.DDD.Application.Companies.Company.Commands.Common;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Create
{
    public class CreateCompanyCommand : CompanyCommand<CreateCompanyCommand>, IRequest<CreateCompanyOutputModel>
    {
        
    }
}