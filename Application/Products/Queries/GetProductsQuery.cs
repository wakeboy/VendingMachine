using MediatR;

namespace VendingMachine.Application.Products.Queries;

public class GetProductsQuery : IRequest<ProductsVm>
{
}
