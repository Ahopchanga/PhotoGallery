using PhotoGallery.Entities;

namespace PhotoGallery.Interfaces.Repositories;

public interface IPhotoRepository : IRepository<Photo, Guid>
{
}