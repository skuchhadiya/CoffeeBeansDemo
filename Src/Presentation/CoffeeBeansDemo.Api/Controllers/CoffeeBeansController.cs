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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllCoffeeBeansProductsQuery()));
        }

        [HttpPut]
        public async Task<IActionResult> Add([FromBody] EditableCoffeeBeanProduct requestPayload)
        {
            return Ok(await mediator.Send(new AddProductCommand() { RequestPayload = requestPayload }));
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] CoffeeBeanEditDto requestPayload)
        {
           // return Ok();
            return Ok(await mediator.Send(new EditProductCommand() { RequestPayload = requestPayload }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            return Ok(await mediator.Send(new RemoveProductCommand() { Id = id }));
        }

        //In real word this route must be sucure
        [HttpGet("botd")]
        public async Task<IActionResult> GetBotdData()
        {
            return Ok(await mediator.Send(new GetBOTDProductInformationQuery()));
        }


        //In real word this route must be sucure
        [HttpGet("seed-data")]
        public async Task<IActionResult> SeedData()
        {
            return Ok(await mediator.Send(new RunInitialDataSeedCommand()));
        }
    }
}
