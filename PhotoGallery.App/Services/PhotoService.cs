using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Repositories;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class PhotoService: IPhotoService<PhotoModel>
{
    private readonly IPhotoRepository _repository;
    private readonly IAlbumRepository _albumRepository;

    public PhotoService(IPhotoRepository repository, IAlbumRepository albumRepository)
    {
        _repository = repository;
        _albumRepository = albumRepository;
    }
    
    public async Task AddAsync(PhotoModel model)
    {
        var photo = PhotoModel.Map(model);
        if (photo.AlbumId == 0)
        {
            throw new ArgumentException("Invalid album ID: 0");
        }
        
        // Use GetByIdAsync to check album existence
        var album = await _albumRepository.GetByIdAsync(photo.AlbumId);
        if (album == null)
        {
            throw new InvalidOperationException($"Attempt to add a photo to a non-existent album with ID {photo.AlbumId}");
        }

        await _repository.AddAsync(photo);
    }

    public async Task<List<PhotoModel>> GetAllByAlbumIdAsync(int albumId)
    {
        var allPhotos = await _repository.GetAllAsync();
        var photos = allPhotos.Where(p => p.AlbumId == albumId).ToList();
        var photoModels = photos.Select(PhotoModel.Map).ToList();

        return photoModels;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(PhotoModel model)
    {
        var photo = PhotoModel.Map(model);
        await _repository.UpdateAsync(photo);
    }
}