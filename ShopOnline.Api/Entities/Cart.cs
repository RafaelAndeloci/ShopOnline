using ShopOnline.Api.Abstractions;

namespace ShopOnline.Api.Entities;

public class Cart : Entity
{
    public int Id { get; set; }
    public int UserId { get; set; }
}