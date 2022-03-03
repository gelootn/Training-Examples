using Microservices.Common.DAL.Contracts;
using MicroServices.CompanyService.DAL.Database;
using MicroServices.CompanyService.DAL.Repositories;
using MicroServices.CompanyService.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServices.CompanyService.DAL.Infrastructure
{
    public static class ExtensionsForIServiceCollection
    {
        public static void AddDal(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CompanyServiceDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
