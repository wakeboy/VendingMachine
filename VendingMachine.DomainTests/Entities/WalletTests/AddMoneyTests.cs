namespace VendingMachine.DomainTests.Entities.WalletTests;

public class AddMoneyTests
{
    private readonly Wallet _sut;

    public AddMoneyTests()
    {
        _sut = new Wallet(Guid.NewGuid().ToString());
    }

    [Theory]
    [InlineData(5.50)]
    [InlineData(7.50)]
    [InlineData(20)]
    [InlineData(0.5)]
    public void AddMoneyShouldIncrementBalance(decimal amount)
    {
        _sut.AddMoney(amount);

        _sut.Balance.Should().Be(amount);
    }

    [Theory]
    [InlineData(-5.50)]
    [InlineData(-7.50)]
    [InlineData(-20)]
    [InlineData(-0.5)]
    public void AddMoneyShouldThrowArgumentExceptionWhenAmountNegative(decimal amount)
    {
        var result = () => _sut.AddMoney(amount);

        result.Should().Throw<ArgumentException>();
    }
}
