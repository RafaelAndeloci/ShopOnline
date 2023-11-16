using ShopOnline.Core.Shared;

namespace ShopOnline.Domain.Entities;

public class CartItem : Entity
{
    public CartItem(Guid id, Guid cartId) : base(id)
    {
        CartId = cartId;
    }

    public Guid CartId { get; private set; }
    public Guid ProductId { get; set; }
    public Guid Quantity { get; set; }
    public decimal TotalPrice { get; private set; }
}