using CoffeeBeansDemo.Infrastructure.Abstrartions;
using CoffeeBeansDemo.Infrastructure.HostedServices;
using CoffeeBeansDemo.Infrastructure.Repository;
using Coravel;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBeansDemo.Infrastructure
{
    public static class InfrastructureServiceInjector
    {
        public static IServiceCollection AddInfrastructureServiceInjector(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeBeansRepository, CoffeeBeansRepository>();
            services.AddHostedService<SchedulerBackgroundService> ();
            services.AddScheduler();
            return services;
        }
    }
}
