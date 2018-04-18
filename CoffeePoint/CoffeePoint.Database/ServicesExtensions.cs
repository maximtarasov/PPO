using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeePoint.Database
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContextPool<DatabaseContext>(builder => { builder.UseNpgsql(connectionString); });

            return serviceCollection;
        }
    }
}