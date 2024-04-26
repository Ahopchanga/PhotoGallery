using Microsoft.AspNetCore.Hosting;
using PhotoGallery.App.Models;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Repositories;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class PhotoService: IPhotoService<PhotoModel>
{
    private readonly IPhotoRepository _repository;
    private readonly IAlbumRepository _albumRepository;
    private readonly IWebHostEnvironment _environment;

    public PhotoService(IPhotoRepository repository, IAlbumRepository albumRepository, IWebHostEnvironment environment)
    {
        _repository = repository;
        _albumRepository = albumRepository;
        _environment = environment;
    }
    
    public async Task AddAsync(PhotoModel model)
    {
        var path = Path.Combine(_environment.WebRootPath, "images", model.ImageFile.FileName);

        await using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await model.ImageFile.CopyToAsync(fileStream);
        }

        model.Path = "/images/" + model.ImageFile.FileName;

        var photo = PhotoModel.Map(model);
    
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
    
    public async Task LikePhotoAsync(Guid photoId)
    {
        var photo = await _repository.GetByIdAsync(photoId);
        if (photo == null) throw new KeyNotFoundException($"Photo with id {photoId} not found!");
    
        photo.LikeCount++;
        await _repository.UpdateAsync(photo);
    }

    public async Task DislikePhotoAsync(Guid photoId)
    {
        var photo = await _repository.GetByIdAsync(photoId);
        if (photo == null) throw new KeyNotFoundException($"Photo with id {photoId} not found!");
    
        photo.DislikeCount++;
        await _repository.UpdateAsync(photo);
    }
}