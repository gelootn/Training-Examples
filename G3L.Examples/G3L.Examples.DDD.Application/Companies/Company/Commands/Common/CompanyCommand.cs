using G3L.Examples.DDD.Application.Common.Models;

namespace G3L.Examples.DDD.Application.Companies.Company.Commands.Common
{
    public abstract class CompanyCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string CompanyName { get; set; }
    }
}