using System;
using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Repositories;
using G3L.Examples.DDD.Domain.Visiting.Factories.Visit;
using G3L.Examples.DDD.Domain.Visiting.Factories.Visitor;
using G3L.Examples.DDD.Domain.Visiting.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Commands.Register
{
    public class RegisterVisitCommandHandler : IRequestHandler<RegisterVisitCommand, Result>
    {
        private readonly IVisitorDomainRepository _visitorDomainRepository;
        private readonly IVisitDomainRepository _visitDomainRepository;
        private readonly ICompanyDomainRepository _companyDomainRepository;
        private readonly IEmployeeDomainRepository _employeeDomainRepository;
        private readonly IVisitFactory _visitFactory;
        private readonly IVisitorFactory _visitorFactory;

        public RegisterVisitCommandHandler(
            IVisitorDomainRepository visitorDomainRepository, 
            IVisitDomainRepository visitDomainRepository, 
            ICompanyDomainRepository companyDomainRepository,
            IEmployeeDomainRepository employeeDomainRepository,
            IVisitFactory visitFactory,
            IVisitorFactory visitorFactory)
        {
            _visitorDomainRepository = visitorDomainRepository;
            _visitDomainRepository = visitDomainRepository;
            _companyDomainRepository = companyDomainRepository;
            _employeeDomainRepository = employeeDomainRepository;
            _visitFactory = visitFactory;
            _visitorFactory = visitorFactory;
        }
        public async Task<Result> Handle(RegisterVisitCommand request, CancellationToken cancellationToken)
        {
            var visitor = await _visitorDomainRepository.FindByEmail(request.Email, cancellationToken);
            var company = await _companyDomainRepository.Find(request.CompanyId, cancellationToken);
            var employee = await _employeeDomainRepository.Find(request.EmployeeId, cancellationToken);
            
            if (visitor == null)
                visitor = _visitorFactory
                    .WithEmail(request.Email)
                    .WithName(request.Name)
                    .WithCompanyName(request.Company)
                    .Build();
            
            var visit = _visitFactory
                .WithStartDate(DateTime.Now)
                .WithCompany(company)
                .WithEmployee(employee)
                .WithVisitor(visitor)
                .Build();

            await _visitDomainRepository.Save(visit, cancellationToken);
            
            return Result.Success;
        }
    }
}