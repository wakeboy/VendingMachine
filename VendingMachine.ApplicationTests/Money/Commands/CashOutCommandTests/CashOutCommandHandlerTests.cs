using System.Transactions;
using FluentAssertions;
using Moq;
using VendingMachine.Application.Common.Interfaces;
using VendingMachine.Application.Money.Commands.CashOutCommand;
using VendingMachine.Domain.Entities;

namespace VendingMachine.ApplicationTests.Money.Commands.CashOutCommandTests;
public class CashOutCommandHandlerTests
{
    private readonly Mock<ITransactionManager> transactionManager = new();
    private readonly Mock<IWalletRepository> walletRepository = new();

    private readonly CashOutCommandHandler _sut;

    public CashOutCommandHandlerTests()
    {
        _sut = new(transactionManager.Object, walletRepository.Object);
    }

    [Fact]
    public async Task HandleShouldReturn0WhenTransactionNotFound()
    {
        var command = new CashOutCommand();

        var result = await _sut.Handle(command, default);

        result.Should().Be(0);
    }

    [Fact]
    public async Task HandleShouldReturn0WhenWalletNotFound()
    {
        var command = new CashOutCommand();
        transactionManager.Setup(p => p.TransactionId).Returns(Guid.NewGuid().ToString());

        var result = await _sut.Handle(command, default);

        result.Should().Be(0);
    }


    [Fact]
    public async Task HandleShouldReturnWalletBalanceWhenWalletFound()
    {
        var transactdionId = Guid.NewGuid().ToString();
        var command = new CashOutCommand();
        var wallet = new Wallet(transactdionId);
        wallet.AddMoney(20m);

        transactionManager.Setup(p => p.TransactionId).Returns(transactdionId);
        walletRepository.Setup(m => m.GetByTransactionId(transactdionId)).Returns(wallet);
        
        var result = await _sut.Handle(command, default);

        result.Should().Be(20);
        wallet.Balance.Should().Be(0);
        transactionManager.Verify(m => m.FinishTransaction(), Times.Once);
    }


}
