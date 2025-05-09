using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBeansDemo.Application.Queries
{
    public class GetAllCoffeeBeansProductsQueryHandler(ICoffeeBeansRepository repository)
    : IRequestHandler<GetAllCoffeeBeansProductsQuery, List<CoffeeBeanDto>>
    {
        public Task<List<CoffeeBeanDto>> Handle(
            GetAllCoffeeBeansProductsQuery request, CancellationToken cancellationToken)
        {
            return repository.GetAllAsync(cancellationToken);
        }
    } 
}
