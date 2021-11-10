using G3L.Examples.DDD.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace G3L.Examples.DDD.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddFactories();
        }

        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
           return services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsMatchingInterface()
                .WithTransientLifetime());
        }
    }
}