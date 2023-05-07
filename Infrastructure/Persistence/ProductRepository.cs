using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Application.Common.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Persistence;

public sealed class ProductRepository : IProductRepository
{
    private List<Product> _products = new()
    {
        new Product(1, "Mars Bar", 10, 3.00m),
        new Product(2, "M&Ms", 10, 2.80m),
        new Product(3, "Milkybar", 10, 3.00m),
        new Product(4, "Cookie", 10, 3.50m),
        new Product(5, "Salt and Vinegar Chips", 10, 3.80m),
        new Product(6, "Chili Chips", 10, 3.50m),
        new Product(7, "Plain Chips", 10, 3.50m),
        new Product(8, "Doritos", 10, 3.20m),
        new Product(9, "Popcorn", 10, 2.80m)
    };


    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void Save()
    {
    }

    public Product Update(Product product)
    {
        var index = _products.IndexOf(product);

        if (index != -1)
            _products[index] = product;

        return product;
    }
}
