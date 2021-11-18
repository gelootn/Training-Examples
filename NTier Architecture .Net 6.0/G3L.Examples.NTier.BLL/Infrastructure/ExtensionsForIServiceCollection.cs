using G3L.Examples.NTier.BLL.Mapping;
using G3L.Examples.NTier.BLL.Services;
using G3L.Examples.NTier.DAL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace G3L.Examples.NTier.BLL.Infrastructure;

public static class ExtensionsForIServiceCollection
{
    public static void AddBusinessLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDataLayer(connectionString);
        services.AddScoped<IVisitService, VisitService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddAutoMapper(cfg => cfg.AddProfile(typeof(MappingProfile)));
    }
}
