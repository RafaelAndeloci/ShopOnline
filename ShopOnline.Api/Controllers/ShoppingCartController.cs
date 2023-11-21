using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers;

public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IProductRepository _productRepository;

    public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
    {
        try
        {
            var cartItems = await _shoppingCartRepository.GetItems(userId);

            if (cartItems is null)
            {
                return NoContent();
            }

            var products = await _productRepository.GetAll();

            if (products == null)
            {
                throw new Exception("No Products exists in the system");
            }

            var cartItemsDto = cartItems.ConvertToDto(products);

            return Ok(cartItemsDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    } 
}