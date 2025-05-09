using CoffeeBeansDemo.Infrastructure.Abstrartions;
using CoffeeBeansDemo.Infrastructure.HostedServices;
using CoffeeBeansDemo.Infrastructure.Repository;
using CoffeeBeansDemo.Infrastructure.Schedulers;
using Coravel;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBeansDemo.Infrastructure
{
    public static class InfrastructureServiceInjector
    {
        public static IServiceCollection AddInfrastructureServiceInjector(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeBeansRepository, CoffeeBeansRepository>();
           // services.AddSingleton<IMakeBOTDScheduler, MakeBOTDScheduler>();
            services.AddHostedService<SchedulerBackgroundService> ();
            services.AddScheduler();
            return services;
        }
    }
}
