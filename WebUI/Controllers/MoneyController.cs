using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Money.Commands.CashOutCommand;
using VendingMachine.Application.Money.Commands.InsertMoneyCommand;

namespace VendingMachine.WebUI.Controllers;

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

    [HttpPost("cash-out")]
    public async Task<ActionResult> Post()
    {
        return Ok(await mediator.Send(new CashOutCommand()));
    }
}
