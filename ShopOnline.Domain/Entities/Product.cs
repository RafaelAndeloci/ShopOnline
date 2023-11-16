using ShopOnline.Core.Shared;

namespace ShopOnline.Domain.Entities;

public class Product : Entity
{
    private Product(Guid id, string name, string imageUrl, decimal price, int quantity, Guid categoryId) : base(id)
    {
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Quantity = quantity;
        CategoryId = categoryId;
    }

    public static Product Create(Guid id, string name, string imageUrl, decimal price, int quantity, Guid categoryId)
    {
        return new Product(id, name, imageUrl, price, quantity, categoryId);
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? ImageUrl { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public Guid CategoryId { get; private set; }
}