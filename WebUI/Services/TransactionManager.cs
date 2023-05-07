using Microsoft.AspNetCore.Http;
using VendingMachine.Application.Common.Interfaces;

namespace VendingMachine.WebUI.Services;

public class TransactionManager : ITransactionManager
{
    private const string TransactionIdKey = "TransactionId";
    private readonly IHttpContextAccessor httpContextAccessor;

    public TransactionManager(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string? TransactionId => httpContextAccessor?.HttpContext?.Session.GetString(TransactionIdKey);

    public void FinishTransaction()
    {
        httpContextAccessor?.HttpContext?.Session.Clear();
    }

    public string StartTransaction()
    {
        var transactionId = httpContextAccessor?.HttpContext?.Session.GetString(TransactionIdKey);

        if (transactionId == null)
        {
            transactionId = Guid.NewGuid().ToString();
            httpContextAccessor?.HttpContext?.Session.SetString(TransactionIdKey, transactionId);
        }

        return transactionId;
    }
}
