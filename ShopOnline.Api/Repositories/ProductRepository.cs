using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopOnlineDbContext _db;

    public ProductRepository(ShopOnlineDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Product>?> GetAll() => 
        await _db.Products.ToListAsync();

    public async Task<Product> GetById(int id) => 
        await _db.Products.FindAsync(id);

    public void Create(Product entity) => 
        _db.Products.Add(entity);

    public void Update(Product entity) => 
        _db.Update(entity);

    public void Delete(int id) => 
        _db.Remove(_db.Products.First(p => p.Id == id));

    public async Task<IEnumerable<ProductCategory>?> GetAllCategories() => 
        await _db.ProductCategories.ToListAsync();

    public async Task<ProductCategory?> GetCategoryById(int id) =>
        await _db.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
}