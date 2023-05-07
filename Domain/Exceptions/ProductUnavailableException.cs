using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Exceptions;

public class ProductUnavailableException : Exception
{
    public ProductUnavailableException(string productName) :
        base($"{productName} is unavailable")
    {       
    }
}
