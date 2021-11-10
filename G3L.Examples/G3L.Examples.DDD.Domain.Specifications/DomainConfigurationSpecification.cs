using System.Collections.Generic;
using FluentAssertions;
using G3L.Examples.DDD.Domain.Companies.Factories.Company;
using G3L.Examples.DDD.Domain.Companies.Factories.Employee;
using G3L.Examples.DDD.Domain.Visiting.Factories.Visit;
using G3L.Examples.DDD.Domain.Visiting.Factories.Visitor;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace G3L.Examples.DDD.Domain.Specifications
{
    public class DomainConfigurationSpecification
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDomainShouldRegisterFactories()
        {
            var serviceCollection = new ServiceCollection();

            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            services.GetService<IVisitFactory>()
                .Should()
                .NotBeNull();

            services.GetService<IVisitorFactory>()
                .Should()
                .NotBeNull();

            services.GetService<ICompanyFactory>()
                .Should()
                .NotBeNull();

            services.GetService<IEmployeeFactory>()
                .Should()
                .NotBeNull();
            
        }
    }
}