using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
    {
        return (from product in products
                join productCategory in productCategories
                on product.CategoryId equals productCategory.Id
                select new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    CategoryId = product.CategoryId,
                    CategoryName = productCategory.Name
                }).ToList();
    }

    public static ProductDto ConvertToDto(this Product product, ProductCategory category) => 
        new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId,
            CategoryName = category.Name
        };

    public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
    {
        return (from cartItem in cartItems
            join product in products
                on cartItem.ProductId equals product.Id
                select new CartItemDto
                {
                    Id = cartItem.Id,
                    ProductId = cartItem.ProductId,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    ProductImageUrl = product.ImageUrl,
                    Price = product.Price,
                    CartId = cartItem.CartId,
                    Quantity = cartItem.Quantity,
                    TotalPrice = product.Price * cartItem.Quantity
                }).ToList();
    }
    
}