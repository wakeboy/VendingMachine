using FluentValidation;

namespace VendingMachine.Application.Money.Commands;

public class InsertMoneyCommandValidator : AbstractValidator<InsertMoneyCommand>
{
    public InsertMoneyCommandValidator()
    {
        RuleFor(m => m.Amount)
            .NotEmpty();
    }
}
