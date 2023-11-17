using ShopOnline.Api.Abstractions;

namespace ShopOnline.Api.Entities;

public class User : Entity
{
    public int Id { get; set; }
    public string UserName { get; set; }
}