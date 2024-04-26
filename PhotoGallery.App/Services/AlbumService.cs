using Microsoft.AspNetCore.Hosting;
using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Repositories;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class AlbumService : IAlbumService<AlbumModel>
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IWebHostEnvironment _environment;

    public AlbumService(IAlbumRepository albumRepository, IWebHostEnvironment environment)
    {
        _albumRepository = albumRepository;
        _environment = environment;
    }
    
    public async Task AddAsync(AlbumModel albumModel)
    {
        // Ensuring the cover photo path exists
        if (!string.IsNullOrEmpty(albumModel.CoverPhotoPath))
        {
            var path = Path.Combine(_environment.WebRootPath, albumModel.CoverPhotoPath);
            if (!File.Exists(path))
            {
                throw new ArgumentException("Cover photo does not exist at the specified path");
            }
        }

        var albumEntity = AlbumModel.Map(albumModel);
        await _albumRepository.AddAsync(albumEntity);
    }

    public async Task<AlbumModel> GetByIdAsync(int Id)
    {
        var album = await _albumRepository.GetByIdAsync(Id);
        var model = AlbumModel.Map(album);

        return model;
    }

    public async Task<(List<AlbumModel>, int totalRecords)> GetAllAsync(int pageNumber, int pageSize)
    {
        var allAlbums = await _albumRepository.GetAllAsync();
    
        var totalRecords = allAlbums.Count;
        var paginatedAlbums = allAlbums
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        var models = paginatedAlbums.Select(AlbumModel.Map).ToList();

        return (models, totalRecords);
    }

    public async Task DeleteAsync(int id)
    {
        await _albumRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(AlbumModel albumModel)
    {
        var albumEntity = AlbumModel.Map(albumModel);
        await _albumRepository.UpdateAsync(albumEntity);
    }
}