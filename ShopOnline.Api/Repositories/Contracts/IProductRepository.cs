using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<ProductCategory>?> GetAllCategories();
    Task<ProductCategory?> GetCategoryById(int id);
}