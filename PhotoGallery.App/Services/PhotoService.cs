using Microsoft.AspNetCore.Hosting;
using PhotoGallery.App.Models;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Repositories;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class PhotoService: IPhotoService<PhotoModel>
{
    private readonly IPhotoRepository _repository;
    private readonly IWebHostEnvironment _environment;

    public PhotoService(IPhotoRepository repository, IWebHostEnvironment environment)
    {
        _repository = repository;
        _environment = environment;
    }
    
    public async Task AddAsync(PhotoModel model)
    {
        var fileName = Path.GetFileName(model.ImageFile.FileName);
        if(fileName == null)
            throw new ArgumentNullException("File name is empty.");
        
        // validate file name
        if(fileName.Any(c => Path.GetInvalidFileNameChars().Contains(c)))
            throw new ArgumentException("File name contains invalid characters.");
        
        var path = Path.Combine(_environment.WebRootPath, "images", fileName);

        // check if file already exists
        if(File.Exists(path))
            throw new IOException($"A file with the name {fileName} already exists.");
    
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