using MicroServices.CompanyService.BLL.Behaviors;
using MicroServices.CompanyService.BLL.Mapping;
using MicroServices.CompanyService.DAL.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServices.CompanyService.BLL.Infrastructure
{
    public static class ExtensionsForIServiceCollection
    {
        public static void AddBll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDal(configuration.GetConnectionString("demo"));
            services.AddMediatR(typeof(ValidationBehavior<,>).Assembly);
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
