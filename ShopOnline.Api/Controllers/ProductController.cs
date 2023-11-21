using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var products = await _productRepository.GetAll();
            var categories = await _productRepository.GetAllCategories();

            if (products is null || categories is null)
            {
                return NotFound();
            }

            return Ok(products.ConvertToDto(categories));
        }
        catch (Exception e)
        {
            return BadRequest("Erro");
        }
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var product = await _productRepository.GetById(id);

            if (product is null) return BadRequest();
            
            var productCategory = await _productRepository.GetCategoryById(product.CategoryId);

            if (productCategory is null) return BadRequest();
            
            var productDto = product.ConvertToDto(productCategory);
            
            return Ok(productDto);
        }
        catch (Exception)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }

    // public void Create(Product entity)
    // {
    //     
    // }
    //
    // public void Update(Product entity)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public void Delete(int id)
    // {
    //     throw new NotImplementedException();
    // }

    [HttpGet]
    [Route("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories() => Ok(await _productRepository.GetAllCategories());
    
    [HttpGet]
    [Route("GetCategoryById/{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _productRepository.GetCategoryById(id);
        return category is null ? NoContent() : Ok(category);
    }
}