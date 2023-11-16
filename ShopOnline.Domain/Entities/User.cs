using ShopOnline.Core.Shared;

namespace ShopOnline.Domain.Entities;

public class User : Entity
{
    public User(Guid id) : base(id)
    {
    }

    public string UserName { get; private set; }
}