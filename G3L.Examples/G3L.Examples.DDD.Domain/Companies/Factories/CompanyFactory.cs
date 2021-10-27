using G3L.Examples.DDD.Domain.Companies.Models;

namespace G3L.Examples.DDD.Domain.Companies.Factories
{
    public class CompanyFactory : ICompanyFactory
    {
        private string _companyName = default;

        public Company Build()
        {
            return new Company(_companyName);
        }

        public ICompanyFactory WithName(string name)
        {
            _companyName = name;
            return this;
        }
    }
}