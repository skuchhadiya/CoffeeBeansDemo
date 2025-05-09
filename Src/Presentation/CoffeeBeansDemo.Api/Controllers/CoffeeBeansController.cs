using CoffeeBeansDemo.Application.Command;
using CoffeeBeansDemo.Application.Queries;
using CoffeeBeansDemo.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeBeansDemo.Api.Controllers
{
    [Route("api/[controller]")]
    public class CoffeeBeansController(IMediator mediator) : ControllerBase
    {
        //[AllowAnonymous]
        [HttpGet(Name = "GetAllCoffeeBanesProducts")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllCoffeeBeansProductsQuery()));
        }

        //[AllowAnonymous] 
        [HttpGet("botd", Name = "GetBeanOfTheDay")]
        public async Task<IActionResult> GetBotdData()
        {
            return Ok(await mediator.Send(new GetBOTDProductInformationQuery()));
        }

        //[Authorize] //In real word this route must be sucure 
        [HttpPut(Name = "AddCoffeeBanesProduct")]
        public async Task<IActionResult> Add([FromBody] EditableCoffeeBeanProduct requestPayload)
        {
            return Ok(await mediator.Send(new AddProductCommand() { RequestPayload = requestPayload }));
        }


        //[Authorize] //In real word this route must be sucure 
        [HttpPost(Name = "EditCoffeeBanesProduct")]
        public async Task<IActionResult> Edit([FromBody] CoffeeBeanEditDto requestPayload)
        {
           // return Ok();
            return Ok(await mediator.Send(new EditProductCommand() { RequestPayload = requestPayload }));
        }

        //[Authorize] //In real word this route must be sucure 
        [HttpDelete("{id}",Name = "DeleteCoffeeBanesProduct") ]
        public async Task<IActionResult> Delete(Guid id)
        {

            return Ok(await mediator.Send(new RemoveProductCommand() { Id = id }));
        }

        //[Authorize]   //In real word this route must be sucure 
        [HttpGet("seed-data", Name = "SeedDataInTheDatabase")]
        public async Task<IActionResult> SeedData()
        {
            return Ok(await mediator.Send(new RunInitialDataSeedCommand()));
        }
    }
}
