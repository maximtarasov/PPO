using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeePoint.Database
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DatabaseContext>(builder => { builder.UseNpgsql(connectionString, c => c.MigrationsAssembly("CoffeePoint.Web")); });

            return serviceCollection;
        }
    }
}