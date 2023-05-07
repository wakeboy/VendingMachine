using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DomainTests.Entities.WalletTests;
public sealed class SpendTests
{
    private readonly Wallet _sut;

    public SpendTests()
    {
        _sut = new Wallet(Guid.NewGuid().ToString());
    }

    [Theory]
    [InlineData(5.50)]
    [InlineData(7.50)]
    [InlineData(20)]
    [InlineData(0.5)]
    public void SpendShouldDecrementBalance(decimal amount)
    {
        _sut.AddMoney(100);
        _sut.Spend(amount);

        _sut.Balance.Should().Be(100 - amount);
    }

    [Theory]
    [InlineData(-5.50)]
    [InlineData(-7.50)]
    [InlineData(-20)]
    [InlineData(-0.5)]
    public void SpendShouldThrowArgumentExceptionWhenAmountIsNegative(decimal amount)
    {
        var result = () => _sut.Spend(amount);
        result.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(5.50)]
    [InlineData(7.50)]
    [InlineData(20)]
    [InlineData(0.5)]
    public void SpendShouldThrowInvalidOperationExceptionWhenWalletBalenceIsInsufficent(decimal amount)
    {
        var result = () => _sut.Spend(amount);
        result.Should().Throw<InvalidOperationException>();
    }
}
