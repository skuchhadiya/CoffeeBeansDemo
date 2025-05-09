using CoffeeBeansDemo.Application.StaticClasses;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoffeeBeansDemo.Application.Services
{
    public class MakeBOTDService(ILogger<MakeBOTDService> logger, ICoffeeBeansRepository repository) : IMakeBOTDService
    {
        private async Task<Guid> GetNewBOTDId(CancellationToken token)
        {
            var existingBOTD = await repository.GetIQueryable().Where(x => x.IsBOTD == true).SingleOrDefaultAsync(token);
            int[] possibleNewIndexValues = await repository.GetIQueryable().Where(x => x.IsBOTD == false).Select(x => x.Index).ToArrayAsync();
            int minIndex = 0;
            int maxIndex = possibleNewIndexValues.Max() + 1; // Need Add 1 because in random next function maxValue is not part of the selection range
            if (existingBOTD != null)
            {
                Random r = new();
                bool randomNumberResult = RandomIndexGenerator.TryGetRandomIndex(r, minIndex, maxIndex, existingBOTD.Index, possibleNewIndexValues, out int? randomNumber);
                if (randomNumberResult == false)
                {
                    var randomNumberErrorMessage = $"Random number is not within range";
                    logger.LogError(randomNumberErrorMessage + $"MinValue{0},MaxValue: {1}, currentIndex: {2},PossibleNewIndexValues: {3}", minIndex, maxIndex, existingBOTD.Index, JsonConvert.SerializeObject(possibleNewIndexValues));
                    throw new InvalidDataException(randomNumberErrorMessage);
                }
                return await repository.GetIQueryable().Where(x => x.Index == randomNumber).Select(x => x.Id).SingleOrDefaultAsync(token);
            }
            var errorMessage = "BOID record not found to genearte next BOID Id";
            logger.LogError(errorMessage);
            throw new InvalidDataException(errorMessage);
        }

        /// <summary>
        /// This func is reponsibale to select random product and make one item as “bean of the day” BOTD, and make existing item non BOTD, Run on scheduler which excute this function as per Cron Expression( Automatic excute on given schedule)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> StartCreatingNewBOTDAsync(CancellationToken cancellationToken)
        {
            var newId = await GetNewBOTDId(cancellationToken);
            return await repository.MakeBOTDAsync(newId, cancellationToken);
        }
        
    }
}
