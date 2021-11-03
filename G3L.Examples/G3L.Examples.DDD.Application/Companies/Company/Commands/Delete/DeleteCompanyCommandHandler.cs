using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Delete
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Result>
    {
        private readonly ICompanyDomainRepository _repository;

        public DeleteCompanyCommandHandler(ICompanyDomainRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            //todo Check for employees 
            
            return await _repository.Delete(request.Id, cancellationToken);
        }
    }
}