using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.DTOs;

public class AlbumDto
{
    [Required]
    public int AlbumId { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [StringLength(255, ErrorMessage = "The title must be less than 255 characters.")]
    public string Title { get; set; }

    [StringLength(1000, ErrorMessage = "The description must be less than 1000 characters.")]
    public string Description { get; set; }
    
    public string CoverPhotoPath { get; set; }

    public DateTime DateCreated { get; set; }

    public ICollection<PhotoDto> Photos { get; set; }
        
    public virtual UserDto User { get; set; }
}