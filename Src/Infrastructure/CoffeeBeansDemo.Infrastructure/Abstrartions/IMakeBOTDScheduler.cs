namespace CoffeeBeansDemo.Infrastructure.Abstrartions
{
    public interface IMakeBOTDScheduler
    {
        Task StartCreatingNewBOTDAsync(CancellationToken cancellationToken);
    }
}
