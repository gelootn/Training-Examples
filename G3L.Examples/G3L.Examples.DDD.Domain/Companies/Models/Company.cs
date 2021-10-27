using System.Collections.Generic;
using System.Linq;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Events;
using G3L.Examples.DDD.Domain.Employees.Models;

namespace G3L.Examples.DDD.Domain.Companies.Models
{
    public class Company : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Employee> _employees;
        
        internal Company(string name)
        {
            Name = name;
            _employees = new HashSet<Employee>();
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Employee> Employees => _employees.ToList().AsReadOnly();

        public Company UpdateName(string name)
        {
            Name = name;
            return this;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
            RaiseEvent(new EmployeeAddedEvent());
        }
    }
}