using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Common.Models;

namespace G3L.Examples.DDD.Domain.Employees.Models
{
    public class Employee : Entity<int>, IAggregateRoot
    {
        internal Employee(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Employee UpdateName(string name)
        {
            Name = name;
            return this;
        }

        public Employee UpdateEmail(string email)
        {
            Email = email;
            return this;
        }
    }
}