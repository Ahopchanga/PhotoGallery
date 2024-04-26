using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.DTOs;

public class PhotoDto
{
    public Guid PhotoId { get; set; }

    [Required]
    public int AlbumId { get; set; }

    [Required]
    [StringLength(255, ErrorMessage = "The title must be less than 255 characters.")]
    public string Title { get; set; }

    [StringLength(1000, ErrorMessage = "The description must be less than 1000 characters.")]
    public string Description { get; set; }

    [Required]
    public string Path { get; set; }

    public DateTime DateUploaded { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
    
    public virtual AlbumDto Album { get; set; }
}