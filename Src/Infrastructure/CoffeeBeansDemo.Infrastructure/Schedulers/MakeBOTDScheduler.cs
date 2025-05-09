using CoffeeBeansDemo.Infrastructure.Abstrartions;
using Coravel.Scheduling.Schedule.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace CoffeeBeansDemo.Infrastructure.Schedulers
{
    //public class MakeBOTDScheduler(IServiceScopeFactory serviceScopeFactory,ILogger<MakeBOTDScheduler> logger) : IMakeBOTDScheduler
    //{
      
    //    //public async Task StartCreatingNewBOTDAsync(CancellationToken cancellationToken)
    //    //{
    //    //    var scope = serviceScopeFactory.CreateScope();
    //    //    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    //    //    var scheduler = scope.ServiceProvider.GetRequiredService<IScheduler>();

    //    //    var cronExpression = configuration.GetValue<string>("CronExpressionForScheduleBOTD");

    //    //    await Task.Run(() => scheduler.ScheduleAsync(async () => {
    //    //        logger.LogInformation("Start runing MakeBOTDScheduleJob");
    //    //        try
    //    //        {
    //    //            var makeBOTDService = scope.ServiceProvider.GetRequiredService<IMakeBOTDService>();
    //    //            var coffeeBeansRepository = scope.ServiceProvider.GetRequiredService<ICoffeeBeansRepository>();
    //    //            var newId = await makeBOTDService.GetNewBOTDId(cancellationToken);
    //    //            await coffeeBeansRepository.MakeBOTDAsync(newId, cancellationToken);
    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //            string message = ex.Message;
    //    //            logger.LogError(message);
    //    //        }
    //    //        logger.LogInformation("stop runing MakeBOTDScheduleJob");
    //    //    })
    //    //    .Cron(cronExpression)
    //    //    .RunOnceAtStart()
    //    //   .PreventOverlapping("MakeBOTDScheduleJob"));
    //    //}
    //}
}
