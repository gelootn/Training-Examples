using System.Collections.Generic;
using System.Linq;
using G3L.Examples.DDD.Domain.Common;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Events.Company;
using G3L.Examples.DDD.Domain.Companies.Exceptions;

using static G3L.Examples.DDD.Domain.Common.ModelConstants;

namespace G3L.Examples.DDD.Domain.Companies.Models
{
    public class Company : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Employee> _employees;
        
        internal Company(string name)
        {
            Validate(name);
            Name = name;
            _employees = new HashSet<Employee>();
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Employee> Employees => _employees.ToList().AsReadOnly();

        public Company UpdateName(string name)
        {
            Validate(name);
            Name = name;
            return this;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            RaiseEvent(new EmployeeAddedEvent());
        }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidCompanyException>(name, MinNameLength, MaxNameLength, nameof(Name));
        }
    }
}