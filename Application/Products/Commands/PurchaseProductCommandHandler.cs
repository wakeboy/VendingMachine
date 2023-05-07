using MediatR;
using VendingMachine.Application.Common.Exceptions;
using VendingMachine.Application.Common.Interfaces;

namespace VendingMachine.Application.Products.Commands;

public sealed class PurchaseProductCommandHandler : IRequestHandler<PurchaseProductCommand, ProductVm>
{
    private readonly ITransactionManager transaction;
    private readonly IProductRepository productRepository;
    private readonly IWalletRepository walletRepository;

    public PurchaseProductCommandHandler(
        ITransactionManager transaction,
        IProductRepository productRepository,
        IWalletRepository walletRepository)
    {
        this.transaction = transaction;
        this.productRepository = productRepository;
        this.walletRepository = walletRepository;
    }

    public async Task<ProductVm> Handle(PurchaseProductCommand request, CancellationToken cancellationToken)
    {
        var transactionId = transaction.TransactionId;

        var wallet = walletRepository.GetByTransactionId(transactionId);
        if (wallet == null) throw new NotFoundException("Wallet not found insert money");

        var product = productRepository.GetById(request.ProductId);
        if (product == null) throw new NotFoundException($"Product not found {request.ProductId}");

        wallet.Spend(product.Price);
        product.Purchase();

        walletRepository.AddOrUpdate(wallet);
        productRepository.Update(product);
        productRepository.Save();
        walletRepository.Save();
        
        return new ProductVm { 
            Id = product.Id, 
            Name = product.Name, 
            Price = product.Price, 
            Quantity = product.Quantity 
        };
    }
}
