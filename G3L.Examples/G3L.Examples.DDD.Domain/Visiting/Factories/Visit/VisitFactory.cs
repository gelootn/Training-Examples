using System;
using G3L.Examples.DDD.Domain.Companies.Models;

namespace G3L.Examples.DDD.Domain.Visiting.Factories.Visit
{
    public class VisitFactory : IVisitFactory
    {
        private DateTime _startDate = default;
        private Company _company = default;
        private Employee _employee = default;
        private Models.Visitor _visitor = default;
        
        public Models.Visit Build()
        {
            return new Models.Visit(_startDate, _visitor, _company, _employee);
        }

        public IVisitFactory WithStartDate(DateTime date)
        {
            _startDate = date;
            return this;
        }

        public IVisitFactory WithCompany(Company company)
        {
            _company = company;
            return this;
        }

        public IVisitFactory WithEmployee(Employee employee)
        {
            _employee = employee;
            return this;
        }

        public IVisitFactory WithVisitor(Models.Visitor visitor)
        {
            _visitor = visitor;
            return this;
        }
    }
}