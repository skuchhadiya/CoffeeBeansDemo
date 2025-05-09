using CoffeeBeansDemo.Infrastructure.Abstrartions;
using Coravel.Scheduling.Schedule.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoffeeBeansDemo.Infrastructure.HostedServices
{
    public class SchedulerBackgroundService(IServiceScopeFactory serviceScopeFactory,ILogger<SchedulerBackgroundService> logger, IConfiguration configuration,  IScheduler scheduler) : BackgroundService
    {
      
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cronExpression = configuration.GetValue<string>("CronExpressionForScheduleBOTD");
            logger.LogInformation("SchedulerBackgroundService Serice Started: {time}", DateTimeOffset.Now);
            await Task.Run(() => scheduler.ScheduleAsync(async () => {
                logger.LogInformation("Start runing MakeBOTDScheduleJob {0}", DateTimeOffset.Now);
                try
                {
                    var scope = serviceScopeFactory.CreateScope();
                    var makeBOTDService = scope.ServiceProvider.GetRequiredService<IMakeBOTDService>();
                    var result = await makeBOTDService.StartCreatingNewBOTDAsync(stoppingToken);
                    logger.LogInformation("NewBOTD Generated {0}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    logger.LogError(message + $"{0}", DateTimeOffset.Now);
                }
                logger.LogInformation("Stop runing MakeBOTDScheduleJob {0}", DateTimeOffset.Now);
            }).Cron(cronExpression)
            .PreventOverlapping("MakeBOTDScheduleJob"));

          // await makeBOTDScheduler.StartCreatingNewBOTDAsync(stoppingToken);

        }
    }
}
