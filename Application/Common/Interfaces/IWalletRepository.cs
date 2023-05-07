using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Common.Interfaces;

public interface IWalletRepository
{
    Wallet? GetByTransactionId(string transactionId);

    Wallet AddOrUpdate(Wallet product);

    void Save();
}
