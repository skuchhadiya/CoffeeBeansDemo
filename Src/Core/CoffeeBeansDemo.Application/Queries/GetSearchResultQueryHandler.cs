using CoffeeBeansDemo.Domain.Entities;
using CoffeeBeansDemo.Infrastructure.Abstrartions;
using MediatR;

namespace CoffeeBeansDemo.Application.Queries
{
    public class GetSearchResultQueryHandler(ICoffeeBeansRepository repository) : IRequestHandler<GetSearchResultQuery, List<CoffeeBeanDto>>
    {
        public Task<List<CoffeeBeanDto>> Handle(
            GetSearchResultQuery request, CancellationToken cancellationToken)
        {
            return repository.GetSearchAsync(request.SearchParams, cancellationToken);
        }
    }
}
