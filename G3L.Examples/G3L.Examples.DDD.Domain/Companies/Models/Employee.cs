using System.Runtime.CompilerServices;
using G3L.Examples.DDD.Domain.Common;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Common.Models;
using G3L.Examples.DDD.Domain.Companies.Exceptions;

using static G3L.Examples.DDD.Domain.Common.ModelConstants;

namespace G3L.Examples.DDD.Domain.Companies.Models
{
    public class Employee : Entity<int>, IAggregateRoot
    {
        internal Employee(string name, string email)
        {
            Validate(name, email);
            Name = name;
            Email = email;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Employee UpdateName(string name)
        {
            ValidateName(name);
            Name = name;
            return this;
        }

        public Employee UpdateEmail(string email)
        {
            ValidateEmail(email);
            Email = email;
            return this;
        }

        private void Validate(string name, string email)
        {
            ValidateName(name);
            ValidateEmail(email);
        }
        private void ValidateName(string name)
        {
            Guard.ForStringLength<InvalidEmployeeException>(name, MinNameLength, MaxNameLength, nameof(Name));
        }

        private void ValidateEmail(string email)
        {
            Guard.ForStringLength<InvalidEmployeeException>(email, MinNameLength, MaxNameLength, nameof(Email));
        }
    }
}