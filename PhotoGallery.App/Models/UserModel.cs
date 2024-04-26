using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Models;

namespace PhotoGallery.App.Models;

public class UserModel : IUserModel
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }

    public static UserModel Map(User user)
    {
        return new UserModel {
            UserId = user.Id,
            Username = user.UserName,
            Role = user.Role
        };
    }

    public static User Map(UserModel model)
    {
        return new User {
            Id = model.UserId,
            UserName = model.Username,
            Role = model.Role
        };
    }
}