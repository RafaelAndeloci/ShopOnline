using ShopOnline.Api.Abstractions;

namespace ShopOnline.Api.Entities;

public class CartItem : Entity
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}