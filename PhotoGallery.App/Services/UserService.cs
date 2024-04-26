using Microsoft.AspNetCore.Identity;
using PhotoGallery.DTOs;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Add(UserDto userDto)
    {
        var user = User.Map(userDto);
        var result = await _userManager.CreateAsync(user);

        return result.Succeeded;
    }

    public async Task<UserDto> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return user == null ? null : User.Map(user);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        return _userManager.Users.AsEnumerable().Select(User.Map);
    }

    public async Task<bool> Update(UserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.UserId);
        if (user == null)
        {
            return false;
        }
        
        user.UserName = userDto.Username;
        user.Role = userDto.Role;

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return false;
        }

        var result = await _userManager.DeleteAsync(user);

        return result.Succeeded;
    }
}