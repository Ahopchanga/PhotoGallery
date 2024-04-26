using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Repositories;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class AlbumService : IAlbumService<AlbumModel>
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    
    public async Task AddAsync(AlbumModel albumModel)
    {
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