using CoffeeBeansDemo.Domain.Entities;
using MediatR;

namespace CoffeeBeansDemo.Application.Queries
{
    public class GetAllCoffeeBeansProductsQuery: IRequest<List<CoffeeBeanDto>>
    {
    }
}
