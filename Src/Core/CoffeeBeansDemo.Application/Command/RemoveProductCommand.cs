using MediatR;

namespace CoffeeBeansDemo.Application.Command
{
    public class RemoveProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
