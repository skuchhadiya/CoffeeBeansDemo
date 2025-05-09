using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Domain.Models;
using MediatR;
namespace CoffeeBeansDemo.Application.Queries
{
    public record GetSearchResultQuery: IRequest<List<CoffeeBeanDto>>
    {
        public SearchParams SearchParams { get; set; }
    }
}
