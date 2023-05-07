using MediatR;

namespace VendingMachine.Application.Products.Commands;
public record PurchaseProductCommand : IRequest<PurchaseProductVm>
{
    public int ProductId { get; set; }
}
