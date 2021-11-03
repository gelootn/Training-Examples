using G3L.Examples.DDD.Domain.Common.Interfaces;

namespace G3L.Examples.DDD.Domain.Companies.Factories.Employee
{
    public interface IEmployeeFactory : IFactory<Models.Employee>
    {
        IEmployeeFactory WithName(string name);
        IEmployeeFactory WithEmail(string email);
    }
}