using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.DTOs;

public class UserDto
{
    [Required]
    public string UserId { get; set; }

    [Required]
    [StringLength(256, ErrorMessage = "The username must be less than 256 characters.")]
    public string Username { get; set; }

    [Required] 
    public string Role { get; set; } = "DefaultRole";

    public ICollection<AlbumDto> Albums { get; set; }
}