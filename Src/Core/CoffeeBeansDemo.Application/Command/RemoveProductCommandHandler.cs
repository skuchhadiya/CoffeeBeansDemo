using CoffeeBeansDemo.Infrastructure.Abstrartions;
using MediatR;
namespace CoffeeBeansDemo.Application.Command
{

    public class RemoveProductCommandHandler(ICoffeeBeansRepository repository)
   : IRequestHandler<RemoveProductCommand, int>
    {
        public async Task<int> Handle(
            RemoveProductCommand command, CancellationToken cancellationToken)
        {

            return await repository.RemoveAsync(command.Id, cancellationToken);
        }
    }
}
