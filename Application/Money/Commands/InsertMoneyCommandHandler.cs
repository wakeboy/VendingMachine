using MediatR;
using VendingMachine.Application.Common.Interfaces;

namespace VendingMachine.Application.Money.Commands;

public class InsertMoneyCommandHandler : IRequestHandler<InsertMoneyCommand, MoneyVm>
{
    private readonly ITransactionManager transactionManager;
    private readonly IWalletRepository repository;

    public InsertMoneyCommandHandler(
        ITransactionManager transactionManager,
        IWalletRepository repository)
    {
        this.transactionManager = transactionManager;
        this.repository = repository;
    }

    public async Task<MoneyVm> Handle(InsertMoneyCommand request, CancellationToken cancellationToken)
    {
        var transactionId = transactionManager.TransactionId ?? transactionManager.StartTransaction();

        var wallet =
            repository.GetByTransactionId(transactionId) ?? new Domain.Entities.Wallet(transactionManager.TransactionId);

        wallet.AddMoney(request.Amount.Value);
        repository.AddOrUpdate(wallet);
        repository.Save();

        return new MoneyVm { Balance = wallet.Balance };
    }
}
