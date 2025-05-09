using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Domain.Models;
using CoffeeBeansDemo.Persistence.Entities;

namespace CoffeeBeansDemo.Infrastructure.Abstrartions
{
    public interface ICoffeeBeansRepository
    {
        IQueryable<CoffeeBean> GetIQueryable();
        Task<List<CoffeeBeanDto>> GetAllAsync(CancellationToken token);
        Task<CoffeeBeanDto?> AddAsync(CoffeeBean coffeeBean, CancellationToken token);
        Task<int> UpdateAsync(CoffeeBeanEditDto coffeeBeanDto, CancellationToken token);

        Task<int> RemoveAsync(Guid id, CancellationToken token);

        Task<bool> SeedDataAsync(List<CoffeeBean> data, CancellationToken token);

        /// <summary>
        /// User can only make one "Bean of the Day(BOTD)" at a time 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> MakeBOTDAsync(Guid id, CancellationToken token);

    }
}
