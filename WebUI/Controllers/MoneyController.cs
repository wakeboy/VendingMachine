using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Money.Commands;

namespace VendingMachine.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private readonly IMediator mediator;

        public MoneyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] InsertMoneyCommand request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
