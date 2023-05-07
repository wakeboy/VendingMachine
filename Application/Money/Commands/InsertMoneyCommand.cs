using MediatR;

namespace VendingMachine.Application.Money.Commands;

public record InsertMoneyCommand : IRequest<MoneyVm>
{
    public decimal? Amount { get; set; }
};
