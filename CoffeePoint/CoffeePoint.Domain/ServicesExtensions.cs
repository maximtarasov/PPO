using System;
using CoffeePoint.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeePoint.Domain
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UsersService>();
            serviceCollection.AddScoped<ShiftsService>();
            serviceCollection.AddScoped<ProductsService>();
            serviceCollection.AddScoped<AccountsService>();
            
            serviceCollection.AddScoped<DataInitializationService>();
            
            return serviceCollection;
        }
    }
}