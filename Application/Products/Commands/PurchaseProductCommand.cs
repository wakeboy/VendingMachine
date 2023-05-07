using MediatR;

namespace VendingMachine.Application.Products.Commands;
public record PurchaseProductCommand : IRequest<ProductVm>
{
    public int ProductId { get; set; }
}
