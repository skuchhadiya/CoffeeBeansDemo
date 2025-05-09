using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Domain.Models;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using CoffeeBeansDemo.Persistence;
using CoffeeBeansDemo.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBeansDemo.Infrastructure.Repository
{
    public class CoffeeBeansRepository(CoffeeBeansDemoContext context) : ICoffeeBeansRepository
    {
        public async Task<CoffeeBeanDto?> AddAsync(CoffeeBean coffeeBean, CancellationToken token)
        {
            var item = await context.CoffeeBeans.AddAsync(coffeeBean, token);
            context.SaveChanges();
            item.CurrentValues.TryGetValue("Id", out Guid id);
            return (await GetAllAsync(token)).SingleOrDefault(x=> x.Id == id);
        }

        public IQueryable<CoffeeBean> GetIQueryable()
        {
            return context.CoffeeBeans.AsQueryable();
        }

        public Task<List<CoffeeBeanDto>> GetAllAsync(CancellationToken token)
        {
            return context.CoffeeBeans.AsNoTracking().Select(x => new CoffeeBeanDto(x)).ToListAsync(token);

        }

        public Task<int> UpdateAsync(CoffeeBeanEditDto coffeeBeanDto, CancellationToken token)
        {
            var entity = context.CoffeeBeans.SingleOrDefault(x => x.Id == new Guid(coffeeBeanDto.Id));
            if (entity == null) {
                throw new NullReferenceException($"Provided Id not found id:{coffeeBeanDto.Id}");
            }
            return context.CoffeeBeans.Where(x => x.Id == new Guid(coffeeBeanDto.Id))
                .ExecuteUpdateAsync(x => x
                .SetProperty(p => p.Name, coffeeBeanDto.Name)
                    .SetProperty(p =>p.Description, coffeeBeanDto.Description)
                      .SetProperty(p => p.Cost, coffeeBeanDto.Cost)
                        .SetProperty(p => p.Colour, coffeeBeanDto.Colour)
                          .SetProperty(p => p.IsBOTD, bool.Parse(coffeeBeanDto.IsBOTD))
                            .SetProperty(p => p.Image, coffeeBeanDto.Image)
                ,token);

        }

        public Task<CoffeeBeanDto?> GetCurrentBOTDAsync(CancellationToken token)
        {
            return context.CoffeeBeans.AsNoTracking()
                .Select(x => new CoffeeBeanDto(x))
                .Where(x => x.IsBOTD == true)
                .SingleOrDefaultAsync(token);
        }

        public async Task<bool> MakeBOTDAsync(Guid id, CancellationToken token)
        {
            //Logic for only make One BOTD at time
            using (var transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.RepeatableRead)){
                try
                {
                    var entity = await context.CoffeeBeans.Where(x => x.Id == id)
                        .SingleOrDefaultAsync(token);
                    var existingBOTD = await context.CoffeeBeans.Where(x => x.IsBOTD == true)
                        .SingleOrDefaultAsync(token);

                    if (existingBOTD != null)
                    {
                        existingBOTD.IsBOTD = false;
                        context.CoffeeBeans.Update(existingBOTD);

                    }
                    if (entity != null)
                    {
                        entity.IsBOTD = true;
                        context.CoffeeBeans.Update(entity);
                    }
                    await context.SaveChangesAsync(token);
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Task<int> RemoveAsync(Guid id, CancellationToken token)
        {
          
            return context.CoffeeBeans.Where( x=> x.Id == id).ExecuteDeleteAsync(token);
        }

        public async Task<bool> SeedDataAsync(List<CoffeeBean> data, CancellationToken token)
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync(token);
            return true; 
        }
    }
}
