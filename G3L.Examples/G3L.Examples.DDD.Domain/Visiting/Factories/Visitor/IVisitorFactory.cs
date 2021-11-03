using G3L.Examples.DDD.Domain.Common.Interfaces;

namespace G3L.Examples.DDD.Domain.Visiting.Factories.Visitor
{
    public interface IVisitorFactory : IFactory<Models.Visitor>
    {
        IVisitorFactory WithName(string name);
        IVisitorFactory WithEmail(string email);
        IVisitorFactory WithCompanyName(string companyName);
    }
}