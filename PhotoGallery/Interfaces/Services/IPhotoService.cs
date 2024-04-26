using PhotoGallery.Interfaces.Models;

namespace PhotoGallery.Interfaces.Services;

public interface IPhotoService<TModel> where TModel : IPhotoModel
{
    Task AddAsync(TModel photo);

    Task<List<TModel>> GetAllByAlbumIdAsync(int albumId);

    Task DeleteAsync(int Id);
    
    Task UpdateAsync(TModel model);
}