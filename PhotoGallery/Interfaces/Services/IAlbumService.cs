using PhotoGallery.Interfaces.Models;

namespace PhotoGallery.Interfaces.Services;

public interface IAlbumService<TModel> where TModel : IAlbumModel
{
    Task AddAsync(TModel model);

    Task<TModel> GetByIdAsync(int Id);

    Task<(List<TModel>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize);

    Task DeleteAsync(int Id);
    
    Task UpdateAsync(TModel model);
}