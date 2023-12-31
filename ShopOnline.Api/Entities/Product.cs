﻿using ShopOnline.Api.Abstractions;

namespace ShopOnline.Api.Entities;

public class Product : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}