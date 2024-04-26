using Microsoft.AspNetCore.Identity;
using PhotoGallery.App.Models;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;
public class UserService : IUserService<UserModel>
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Add(UserModel userModel)
    {
        var user = UserModel.Map(userModel);
        var result = await _userManager.CreateAsync(user);

        return result.Succeeded;
    }

    public async Task<UserModel> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return user == null ? null : UserModel.Map(user);
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        var users = _userManager.Users;
        return users.AsEnumerable().Select(UserModel.Map);
    }

    public async Task<bool> Update(UserModel userModel)
    {
        var user = await _userManager.FindByIdAsync(userModel.UserId);
        if (user == null)
        {
            return false;
        }
        
        user.UserName = userModel.Username;
        user.Role = userModel.Role;

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