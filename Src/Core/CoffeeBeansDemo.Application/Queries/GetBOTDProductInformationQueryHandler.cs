using CoffeeBeansDemo.Infrastructure.Abstrartions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoffeeBeansDemo.Application.Queries
{
    public class GetBOTDProductInformationQueryHandler(ICoffeeBeansRepository repository) :IRequestHandler<GetBOTDProductInformationQuery,string>
    {
        public async Task<string> Handle(
            GetBOTDProductInformationQuery request, CancellationToken cancellationToken)
        {
            var botdItem = await repository.GetIQueryable().AnyAsync(x => x.IsBOTD == true, cancellationToken);
            // I am just putting this static msg,  in realworld applicatin it can be obtained from any database
            string msg = "Well done you have selected Bean of the Day item, You have 10% discount on this product if you purchase this item, We'll autometiaclly apply discount at checkout";
            return msg;
        }
    }
}
