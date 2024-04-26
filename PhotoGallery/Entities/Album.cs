using PhotoGallery.DTOs;
using PhotoGallery.Interfaces;

namespace PhotoGallery.Entities;

public class Album : IEntity
{
    public int AlbumId { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public string CoverPhotoPath { get; set; }

    
    public virtual List<Photo> Photos { get; set; }

    public static AlbumDto Map(Album album)
    {
        return new AlbumDto
        {
            AlbumId = album.AlbumId,
            UserId = album.UserId,
            Title = album.Title,
            Description = album.Description,
            CoverPhotoPath = album.CoverPhotoPath 
        };
    }
    
    public static Album Map(AlbumDto album)
    {
        return new Album
        {
            AlbumId = album.AlbumId,
            UserId = album.UserId,
            Title = album.Title,
            Description = album.Description,
            CoverPhotoPath = album.CoverPhotoPath 
        };
    }
}