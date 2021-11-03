using System;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Companies.Models;

namespace G3L.Examples.DDD.Domain.Visiting.Factories.Visit
{
    public interface IVisitFactory : IFactory<Models.Visit>
    {
        IVisitFactory WithStartDate(DateTime date);
        
        IVisitFactory WithCompany(Company company);

        IVisitFactory WithEmployee(Employee employee);

        IVisitFactory WithVisitor(Models.Visitor visitor);




    }
}