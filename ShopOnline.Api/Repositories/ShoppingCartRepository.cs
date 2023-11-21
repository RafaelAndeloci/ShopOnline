using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly ShopOnlineDbContext _db;

    public ShoppingCartRepository(ShopOnlineDbContext db)
    {
        _db = db;
    }

    private async Task<bool> CartItemAlreadyExists(int cartId, int productId) => 
        await _db.CartItems.AnyAsync(c => c.CartId == cartId && c.ProductId == productId);
    

    public async Task<CartItem?> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        if (!await CartItemAlreadyExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId))
        {
            var item = await (from product in _db.Products
                where product.Id == cartItemToAddDto.ProductId
                select new CartItem
                {
                    CartId = cartItemToAddDto.CartId,
                    ProductId = product.Id,
                    Quantity = cartItemToAddDto.Quantity
                }).SingleOrDefaultAsync();

            if (item is not null)
            {
                var result = await _db.CartItems.AddAsync(item);
                await _db.SaveChangesAsync();
                return result.Entity;
            }
        }
        

        return null;
    }

    public async Task<CartItem> UpdateQuantity(int id, CartItemQuantityUpdateDto cartItemQuantityUpdateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<CartItem> DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CartItem?> GetItem(int id)
    {
        return await (from cart in _db.Carts
                      join cartItem in _db.CartItems
                      on cart.Id equals cartItem.CartId
                      where cartItem.Id == id
                      select new CartItem
                      {
                          Id = cartItem.Id,
                          ProductId = cartItem.ProductId,
                          Quantity = cartItem.Quantity,
                          CartId = cartItem.CartId
                      }).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<CartItem>?> GetItems(int userId)
    {
        return await (from cart in _db.Carts
                      join cartItem in _db.CartItems
                          on cart.Id equals cartItem.CartId
                      where cart.UserId == userId
                      select new CartItem
                      {
                          Id = cartItem.Id,
                          ProductId = cartItem.ProductId,
                          Quantity = cartItem.Quantity,
                          CartId = cartItem.CartId
                      }).ToListAsync();
    }
}