using VendingMachine.Application.Common.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Persistence;

internal sealed class WalletRepository : IWalletRepository
{
    private List<Wallet> _wallets = new();


    public Wallet? GetByTransactionId(string transactionId)
    {
        return _wallets.FirstOrDefault(p => p.TransactionId == transactionId);
    }

    public Wallet AddOrUpdate(Wallet wallet)
    {
        var index = _wallets.IndexOf(wallet);

        if(index != -1)
            _wallets[index] = wallet;
        else 
            _wallets.Add(wallet);

        return wallet;
    }

    public void Save()
    {
    }
}