using FluentValidation.Results;
using MediatR;
using VendingMachine.Application.Common.Interfaces;

namespace VendingMachine.Application.Money.Commands.CashOutCommand;

public class CashOutCommandHandler : IRequestHandler<CashOutCommand, decimal>
{
    private readonly ITransactionManager transactionManager;
    private readonly IWalletRepository walletRepository;

    public CashOutCommandHandler(
        ITransactionManager transactionManager,
        IWalletRepository walletRepository)
    {
        this.transactionManager = transactionManager;
        this.walletRepository = walletRepository;
    }

    public async Task<decimal> Handle(CashOutCommand request, CancellationToken cancellationToken)
    {
        var transactionId = transactionManager.TransactionId;
        if (transactionId == null) return 0m;

        var wallet = walletRepository.GetByTransactionId(transactionId);
        if (wallet == null) return 0m;

        var returnAmount = wallet.Balance;

        wallet.Empty();
        walletRepository.AddOrUpdate(wallet);
        walletRepository.Save();

        transactionManager.FinishTransaction();

        return returnAmount;
    }
}
