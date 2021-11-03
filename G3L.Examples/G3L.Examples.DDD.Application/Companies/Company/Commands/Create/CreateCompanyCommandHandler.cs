using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Domain.Companies.Factories.Company;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Create
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyOutputModel>
    {
        private readonly ICompanyDomainRepository _companyRepository;
        private readonly ICompanyFactory _factory;

        public CreateCompanyCommandHandler(
            ICompanyDomainRepository companyRepository,
            ICompanyFactory factory)
        {
            _companyRepository = companyRepository;
            _factory = factory;
        }
        
        public async Task<CreateCompanyOutputModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _factory.WithName(request.CompanyName).Build();
            await _companyRepository.Save(company, cancellationToken);
            
            return new CreateCompanyOutputModel(company.Id);
        }
    }
}