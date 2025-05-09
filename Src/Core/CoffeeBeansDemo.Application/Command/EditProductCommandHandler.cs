using CoffeeBeansDemo.Infrastructure.Abstrartions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBeansDemo.Application.Command
{
    public class EditProductCommandHandler(ICoffeeBeansRepository repository)
    : IRequestHandler<EditProductCommand, int>
    {
        public async Task<int> Handle(
            EditProductCommand command, CancellationToken cancellationToken)
        {
            if (command.RequestPayload == null)
            {

                throw new ArgumentNullException(nameof(command));
            }
            // checkFor BOTD item
            if (bool.Parse(command.RequestPayload.IsBOTD))
            {
                var botdItem = await repository.GetIQueryable().AnyAsync(x => x.IsBOTD == true, cancellationToken);
                if (botdItem)
                {
                    throw new InvalidOperationException("Only one Bean of the Day(BOTD) can be selected, Item already exist");
                }
            }
            return await repository.UpdateAsync(command.RequestPayload, cancellationToken);
        }
    }
}
