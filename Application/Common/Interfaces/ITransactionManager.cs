namespace VendingMachine.Application.Common.Interfaces;

public interface ITransactionManager
{
    string? TransactionId { get; }

    string StartTransaction();

    void FinishTransaction();
}
