using G3L.Examples.DDD.Domain.Common;
using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Common.Models;
using G3L.Examples.DDD.Domain.Visiting.Exceptions;

namespace G3L.Examples.DDD.Domain.Visiting.Models
{
    public class Visitor : Entity<int>, IAggregateRoot
    {
        internal Visitor(string name, string email, string companyName)
        {
            Validate(name, email, companyName);
            Name = name;
            Email = email;
            CompanyName = companyName;
        }
        
        
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CompanyName { get; private set; }


        private void Validate(string name, string email, string company)
        {
            Guard.AgainstEmptyString<InvalidVisitorException>(name, nameof(Name));
            Guard.AgainstEmptyString<InvalidVisitorException>(email, nameof(Email));
            Guard.AgainstEmptyString<InvalidVisitorException>(company, nameof(CompanyName));
        }
    }
}