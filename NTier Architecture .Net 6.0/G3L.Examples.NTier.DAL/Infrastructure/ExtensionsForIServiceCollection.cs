using G3L.Examples.NTier.DAL.Database;
using G3L.Examples.NTier.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace G3L.Examples.NTier.DAL.Infrastructure;

public static class ExtensionsForIServiceCollection
{
    public static void AddDataLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<NTierDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped(typeof(IAsyncGenericRepository<>), typeof(AsyncGenericRepository<>));
    }
}
