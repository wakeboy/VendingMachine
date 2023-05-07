using MediatR;
using VendingMachine.Application.Common.Interfaces;

namespace VendingMachine.Application.Products.Queries;

public sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsVm>
{
    private readonly IProductRepository productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<ProductsVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = productRepository.GetAll();

        return new ProductsVm 
        { 
            Products = products.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Price = p.Price, Quantity = p.Quantity }).ToList() 
        };
    }
}

