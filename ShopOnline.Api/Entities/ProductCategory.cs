using ShopOnline.Api.Abstractions;

namespace ShopOnline.Api.Entities;

public class ProductCategory : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
}