using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Products.Commands;
using VendingMachine.Application.Products.Queries;

namespace VendingMachine.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await mediator.Send(new GetProductsQuery()));
    }

    [HttpPost("{productId}/purchase")]
    public async Task<ActionResult> Purchase([FromRoute]int productId)
    {
        return Ok(await mediator.Send(new PurchaseProductCommand { ProductId = productId }));
    }
}
