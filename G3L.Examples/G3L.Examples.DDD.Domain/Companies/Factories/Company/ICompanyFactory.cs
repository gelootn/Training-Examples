using G3L.Examples.DDD.Domain.Common.Interfaces;

namespace G3L.Examples.DDD.Domain.Companies.Factories.Company
{
    public interface ICompanyFactory : IFactory<Models.Company>
    {
        ICompanyFactory WithName(string name);
    }
}