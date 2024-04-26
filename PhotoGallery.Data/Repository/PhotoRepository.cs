using Microsoft.EntityFrameworkCore;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Repositories;

namespace PhotoGallery.Data.Repository;

public class PhotoRepository : IPhotoRepository
{
    private readonly GalleryDbContext _context;

    public PhotoRepository(GalleryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Photo entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task<List<Photo>> GetAllAsync()
    {
        var photoDtos = await _context.PhotoDtos.ToListAsync();
        var photo = photoDtos.Select(Photo.Map).ToList();

        return photo;
    }
    
    public async Task<Photo> GetByIdAsync(Guid Id)
    {
        var photoDto = await _context.PhotoDtos.SingleAsync(dto => dto.PhotoId == Id);
        var photo = Photo.Map(photoDto);

        return photo;
    }

    public async Task DeleteAsync(int Id)
    {
        var photoDto = await _context.PhotoDtos.FindAsync(Id);
        _context.PhotoDtos.Remove(photoDto);
        
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Photo entity)
    {
        var existingEntity = await _context.PhotoDtos.FindAsync(entity.PhotoId);
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        }

        await _context.SaveChangesAsync();
    }
}