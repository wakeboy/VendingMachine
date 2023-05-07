namespace VendingMachine.Application.Products.Queries;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
