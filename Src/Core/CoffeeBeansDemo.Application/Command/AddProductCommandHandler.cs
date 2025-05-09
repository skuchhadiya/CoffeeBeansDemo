using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using CoffeeBeansDemo.Persistence.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBeansDemo.Application.Command
{
    public class AddProductCommandHandler(ICoffeeBeansRepository repository)
   : IRequestHandler<AddProductCommand, CoffeeBeanDto?>
    {
        public async Task<CoffeeBeanDto?> Handle(
            AddProductCommand command, CancellationToken cancellationToken)
        {
            if (command.RequestPayload == null)
            {

                throw new ArgumentNullException(nameof(command));
            }
            // checkFor BOTD item
            if (command.RequestPayload.isBOTD)
            {
                var botdItem = await repository.GetIQueryable().AnyAsync(x => x.IsBOTD == true, cancellationToken);
                if (botdItem)
                {
                    throw new InvalidOperationException("Only one Bean of the Day(BOTD) can be selected, Item already exist");
                }
            }

            var maxIndex = await repository.GetIQueryable().Select(x => x.Index).MaxAsync(cancellationToken);
            var newCofeeProduct = new CoffeeBean
            {
                Index = maxIndex+1,
                Name = command.RequestPayload.Name,
                Description = command.RequestPayload.Description,
                Colour = command.RequestPayload.Colour,
                Cost = command.RequestPayload.Cost,
                Country = command.RequestPayload.Country,
                Image = command.RequestPayload.Image,
                IsBOTD = command.RequestPayload.isBOTD
            };

            return await repository.AddAsync(newCofeeProduct, cancellationToken);
        }
    }
}
