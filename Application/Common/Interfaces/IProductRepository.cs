using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Common.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();

    Product? GetById(int id);

    Product Update(Product product);

    void Save();
}
