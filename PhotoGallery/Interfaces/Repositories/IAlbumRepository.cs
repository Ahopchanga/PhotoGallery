using PhotoGallery.Entities;

namespace PhotoGallery.Interfaces.Repositories;

public interface IAlbumRepository : IRepository<Album, int>
{
    Task<List<Album>> GetAllByUserIdAsync(string Id);
}