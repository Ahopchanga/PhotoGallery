using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Models;

namespace PhotoGallery.App.Models;

public class AlbumModel : IAlbumModel
{
    public int AlbumId { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }

    public static AlbumModel Map(Album album)
    {
        return new AlbumModel
        {
            AlbumId = album.AlbumId,
            UserId = album.UserId,
            Title = album.Title,
            Description = album.Description
        };
    }
    
    public static Album Map(AlbumModel album)
    {
        return new Album
        {
            AlbumId = album.AlbumId,
            UserId = album.UserId,
            Title = album.Title,
            Description = album.Description
        };
    }
}