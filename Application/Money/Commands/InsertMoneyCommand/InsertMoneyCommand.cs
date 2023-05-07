using MediatR;

namespace VendingMachine.Application.Money.Commands.InsertMoneyCommand;

public record InsertMoneyCommand : IRequest<MoneyVm>
{
    public decimal? Amount { get; set; }
};
