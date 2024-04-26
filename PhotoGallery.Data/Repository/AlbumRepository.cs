using Microsoft.EntityFrameworkCore;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Repositories;

namespace PhotoGallery.Data.Repository;

public class AlbumRepository : IAlbumRepository
{
    private readonly GalleryDbContext _context;

    public AlbumRepository(GalleryDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Album entity)
    {
        var albumDto = Album.Map(entity);
        await _context.AlbumDtos.AddAsync(albumDto);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Album>> GetAllByUserIdAsync(string userId)
    {
        var albumsDtos = await _context.AlbumDtos
            .Where(a => a.UserId == userId)
            .ToListAsync();
        var albums = albumsDtos.Select(Album.Map).ToList();
    
        return albums;
    }


    public async Task<List<Album>> GetAllAsync()
    {
        var albumsDto = await _context.AlbumDtos.ToListAsync();
        var albums = albumsDto.Select(Album.Map).ToList();

        return albums;
    }

    public async Task<Album> GetByIdAsync(int Id)
    {
        var albumDto = await _context.AlbumDtos.SingleAsync(dto => dto.AlbumId == Id);
        var album = Album.Map(albumDto);

        return album;
    }

    public async Task DeleteAsync(int id)
    {
        var albumDto = await _context.AlbumDtos.FindAsync(id);
        _context.AlbumDtos.Remove(albumDto);
        
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Album entity)
    {
        var existingEntity = await _context.AlbumDtos.FindAsync(entity.AlbumId);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        }

        await _context.SaveChangesAsync();
    }
}