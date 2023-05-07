namespace VendingMachine.Domain.Entities;

public class Wallet
{
    private Wallet()
    {
    }

    public Wallet(string TransactionId)
    {
        this.TransactionId = TransactionId;
    }

    public string TransactionId { get; private set; }
    public decimal Balance { get; private set; } = 0;

    public void AddMoney(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Amount must be greater than 0", nameof(amount));
        
        Balance += amount;
    }

    public void Spend(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Amount must be greater than 0", nameof(amount));
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds for spend");

        Balance -= amount;
    }
}
