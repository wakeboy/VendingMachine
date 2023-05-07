using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.Entities
{
    public sealed class Product
    {
        private Product()
        {
        }

        public Product(int id, string name, int quantity, decimal price)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public bool Purchase()
        {
            if (Quantity < 1) throw new ProductUnavailableException(Name);
            Quantity -= 1;
            return true;
        }
    }
}
