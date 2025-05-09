using CoffeeBeansDemo.Application.Services;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBeansDemo.Application
{
    public static class ApplicationServiceInjector
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<IMakeBOTDService, MakeBOTDService>();
            return services;
        }
    }
}
