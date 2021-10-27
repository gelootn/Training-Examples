using G3L.Examples.DDD.Domain.Common.Interfaces;
using G3L.Examples.DDD.Domain.Companies.Models;

namespace G3L.Examples.DDD.Domain.Companies.Factories
{
    public interface ICompanyFactory : IFactory<Company>
    {
        ICompanyFactory WithName(string name);
    }
}