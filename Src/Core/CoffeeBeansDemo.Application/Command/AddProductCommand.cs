using CoffeeBeansDemo.Domain.Models;
using CoffeeBeansDemo.Domain.Entities;
using MediatR;

namespace CoffeeBeansDemo.Application.Command
{
    public record AddProductCommand: IRequest<CoffeeBeanDto?>
    {
        public EditableCoffeeBeanProduct? RequestPayload {  get; set; }
    }
}
