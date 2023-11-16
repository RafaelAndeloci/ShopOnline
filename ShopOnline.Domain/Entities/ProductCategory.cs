using ShopOnline.Core.Shared;

namespace ShopOnline.Domain.Entities;

public class ProductCategory : Entity
{
    public ProductCategory(Guid id) : base(id)
    { }

    public string Name { get; private set; }
}