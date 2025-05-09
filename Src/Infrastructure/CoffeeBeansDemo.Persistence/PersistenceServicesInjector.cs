using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBeansDemo.Persistence
{
    public static class PersistenceServicesInjector
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CoffeeBeansDemoContext>();
            return services;
        }
    }
}
