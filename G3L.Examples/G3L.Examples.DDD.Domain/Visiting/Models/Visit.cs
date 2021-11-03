using System;
using G3L.Examples.DDD.Domain.Common;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Models;
using G3L.Examples.DDD.Domain.Visiting.Exceptions;

namespace G3L.Examples.DDD.Domain.Visiting.Models
{
    public class Visit : Entity<int>, IAggregateRoot
    {
        internal Visit(DateTime start, Visitor visitor, Company company, Employee employee)
        {
            ValidateStartDate(start);
            Start = start;
            Visitor = visitor;
            Company = company;
            Employee = employee;
        }
        public DateTime Start { get; set; }
        public DateTime? End { get; private set; }
        public Visitor Visitor { get; set; }
        public Company Company { get; set; }
        public Employee Employee { get; set; }


        public Visit UpdateEndDate(DateTime end)
        {
            ValidateEndDate(end);
            End = end;
            return this;
        }

        private void ValidateStartDate(DateTime date)
        {
            Guard.AgainstDateBefore<InvalidVisitException>(date, DateTime.Now);
        }

        private void ValidateEndDate(DateTime date)
        {
            Guard.AgainstDateBefore<InvalidVisitException>(date, Start);
        }
        
    }
}