using MediatR;
using CoffeeBeansDemo.Persistence.Entities;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using Newtonsoft.Json;

namespace CoffeeBeansDemo.Application.Command
{
    public class RunInitialDataSeedCommandHandler(ICoffeeBeansRepository repository)
    : IRequestHandler<RunInitialDataSeedCommand, bool>
    {
        public async Task<bool> Handle(
            RunInitialDataSeedCommand command, CancellationToken cancellationToken)
        {
            var root = Directory.GetCurrentDirectory();
            string jsonData = await File.ReadAllTextAsync( root + @"\DataSeed\data.json", cancellationToken);

            var cofeebensData = new List<CoffeeBean>();
            var data = JsonConvert.DeserializeAnonymousType(jsonData, cofeebensData) ?? [];
         
            return await repository.SeedDataAsync(data, cancellationToken);
        }
    }
}
