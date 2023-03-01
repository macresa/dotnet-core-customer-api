using Application.DTOS;
using Application.Features.Customers.Commands;
using Application.Features.Customers.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender mediator;
        public CustomersController(ISender mediator) => this.mediator = mediator;
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        => Ok(await mediator.Send(new GetAllCustomersQuery()));   

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        => Ok(await mediator.Send(new GetCustomerQuery(id)));
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCustomerDto entity)
        {
            await mediator.Send(new CreateCustomerCommand(entity));

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerDto entity,[FromRoute] int id)
        {
            await mediator.Send(new UpdateCustomerCommand(entity, id));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await mediator.Send(new DeleteCustomerCommand(id));

            return NoContent();
        }
    }
}
