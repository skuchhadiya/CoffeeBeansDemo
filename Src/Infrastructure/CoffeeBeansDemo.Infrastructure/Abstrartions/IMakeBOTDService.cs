namespace CoffeeBeansDemo.Infrastructure.Abstrartions
{
    public interface IMakeBOTDService
    {
        Task<bool> StartCreatingNewBOTDAsync(CancellationToken cancellationToken);
    }
}
