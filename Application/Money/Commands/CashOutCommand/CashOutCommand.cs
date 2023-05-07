using MediatR;

namespace VendingMachine.Application.Money.Commands.CashOutCommand;
public record CashOutCommand : IRequest<decimal>;
