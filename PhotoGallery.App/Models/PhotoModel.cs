using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Models;

namespace PhotoGallery.App.Models;

public class PhotoModel : IPhotoModel
{
    public Guid PhotoId { get; set; }
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Path { get; set; }
    public DateTime DateUploaded { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
    
    public static PhotoModel Map(Photo photo)
    {
        return new PhotoModel
        {
            PhotoId = photo.PhotoId,
            AlbumId = photo.AlbumId,
            Title = photo.Title,
            Description = photo.Description,
            Path = photo.Path,
            DateUploaded = photo.DateUploaded,
            LikeCount = photo.LikeCount,
            DislikeCount = photo.DislikeCount
        };
    }
    
    public static Photo Map(PhotoModel photo)
    {
        return new Photo
        {
            PhotoId = photo.PhotoId,
            AlbumId = photo.AlbumId,
            Title = photo.Title,
            Description = photo.Description,
            Path = photo.Path,
            DateUploaded = photo.DateUploaded,
            LikeCount = photo.LikeCount,
            DislikeCount = photo.DislikeCount
        };
    }
}