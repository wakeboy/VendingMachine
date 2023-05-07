namespace VendingMachine.Domain.Exceptions;

public class ProductUnavailableException : Exception
{
    public ProductUnavailableException(string productName) :
        base($"{productName} is unavailable")
    {       
    }
}
