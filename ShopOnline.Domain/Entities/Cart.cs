using ShopOnline.Core.Shared;

namespace ShopOnline.Domain.Entities;

public class Cart : Entity
{
    public Cart(Guid id, Guid userId) : base(id)
    {
        UserId = userId;
    }

    public Guid UserId { get; private set; }
}