using Microsoft.AspNetCore.Identity;
using PhotoGallery.DTOs;
using PhotoGallery.Interfaces;

namespace PhotoGallery.Entities;

public class User : IdentityUser, IEntity
{
    public string Role { get; set; }

    public static UserDto Map(User user)
    {
        return new UserDto
        {
            UserId = user.Id,
            Username = user.UserName,
            Role = user.Role
        };
    }
    
    public static User Map(UserDto user)
    {
        return new User
        {
            UserName = user.Username,
            Role = user.Role
        };
    }
}