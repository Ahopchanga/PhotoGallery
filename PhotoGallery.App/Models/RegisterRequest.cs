using PhotoGallery.DTOs;

namespace PhotoGallery.App.Models;

public class RegisterRequest
{
    public UserDto User { get; set; }
    public string Password { get; set; }
}