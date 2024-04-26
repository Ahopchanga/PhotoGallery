namespace PhotoGallery.Interfaces.Repositories;

public interface IRepository<TEntity, TId>
{
    Task AddAsync(TEntity entity);

    Task DeleteAsync(int Id);
    
    Task<List<TEntity>> GetAllAsync();

    Task UpdateAsync(TEntity entity);
    
    Task<TEntity> GetByIdAsync(TId Id);
}