using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Domain.Models;
using MediatR;

namespace CoffeeBeansDemo.Application.Command
{
    public record EditProductCommand : IRequest<int>
    {
        public CoffeeBeanEditDto? RequestPayload { get; set; }
    }
}
