using System.Linq;
using FluentValidation;

namespace VendingMachine.Application.Money.Commands.InsertMoneyCommand;

public class InsertMoneyCommandValidator : AbstractValidator<InsertMoneyCommand>
{
    private static readonly List<decimal> ValidDenominations = new List<decimal>()
    {
        0.05m,
        0.10m,
        0.20m,
        0.50m,
        1.00m,
        2.00m,
        5.00m,
        10.00m,
        20.00m,
    };

    public InsertMoneyCommandValidator()
    {
        RuleFor(m => m.Amount)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Amount must not be empty")
            .GreaterThan(0).WithMessage("Amount must be greater than 0")
            .Must(a => MustBeDenomination(a)).WithMessage($"Amount must be one of {string.Join(", ", ValidDenominations)}");
    }

    private bool MustBeDenomination(decimal? amount)
    {
        return ValidDenominations.Any(a => a == amount);
    }
}
