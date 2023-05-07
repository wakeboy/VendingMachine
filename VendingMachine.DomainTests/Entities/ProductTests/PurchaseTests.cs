using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DomainTests.Entities.ProductTests;

public class PurchaseTests
{
    private readonly Product _sut;

    public PurchaseTests()
    {
        _sut = new(1, "Test Product", 10, 54.00m);
    }

    [Fact]
    public void PurchaseShouldReduceQuantityByOne()
    {
        _sut.Purchase();
        _sut.Quantity.Should().Be(9);
    }
}
