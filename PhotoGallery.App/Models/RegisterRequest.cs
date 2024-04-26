using System.ComponentModel.DataAnnotations;
using PhotoGallery.Entities;

namespace PhotoGallery.App.Models;

public class RegisterRequest
{
    [Required(ErrorMessage = "User is required")]
    public User User { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, ErrorMessage = "Password length must be between 8 and 100.", MinimumLength = 8)]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; }
}