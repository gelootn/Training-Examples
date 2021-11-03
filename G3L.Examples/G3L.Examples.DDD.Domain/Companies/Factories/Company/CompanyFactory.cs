namespace G3L.Examples.DDD.Domain.Companies.Factories.Company
{
    public class CompanyFactory : ICompanyFactory
    {
        private string _companyName = default;

        public Models.Company Build()
        {
            return new Models.Company(_companyName);
        }

        public ICompanyFactory WithName(string name)
        {
            _companyName = name;
            return this;
        }
    }
}