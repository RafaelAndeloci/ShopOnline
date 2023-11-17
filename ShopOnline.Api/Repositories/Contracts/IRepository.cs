using ShopOnline.Api.Abstractions;

namespace ShopOnline.Api.Repositories.Contracts;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>?> GetAll();
    Task<TEntity?> GetById(int id);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}