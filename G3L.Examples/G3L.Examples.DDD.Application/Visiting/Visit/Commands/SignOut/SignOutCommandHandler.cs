using System;
using System.Threading;
using System.Threading.Tasks;
using G3L.Examples.DDD.Application.Common.Models;
using G3L.Examples.DDD.Domain.Visiting.Repositories;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Commands.SignOut
{
    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, Result>
    {
        private readonly IVisitDomainRepository _repository;

        public SignOutCommandHandler(IVisitDomainRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            var visit = await _repository.FindByVisitor(request.Email, cancellationToken);
            
            if(visit == null) return Result.Failure(new []{ $"no visit found for email {request.Email}" });

            visit.UpdateEndDate(DateTime.Now);

            await _repository.Save(visit, cancellationToken);
            
            return Result.Success;
        }
    }
}