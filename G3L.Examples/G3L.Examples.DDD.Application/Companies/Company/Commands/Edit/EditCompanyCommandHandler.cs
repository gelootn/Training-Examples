using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Edit
{
    public class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, Result>
    {
        private readonly ICompanyDomainRepository _repository;

        public EditCompanyCommandHandler(ICompanyDomainRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.Find(request.Id, cancellationToken);
            
            company.UpdateName(request.CompanyName);
            await _repository.Save(company, cancellationToken);

            return Result.Success;
        }
    }
}