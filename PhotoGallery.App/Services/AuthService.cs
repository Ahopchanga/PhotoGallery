using Microsoft.AspNetCore.Identity;
using PhotoGallery.DTOs;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(UserDto userDto, string password)
    {
        var user = User.Map(userDto);
        var result = await _userManager.CreateAsync(user, password);

        return result;
    }

    public async Task<SignInResult> LoginAsync(UserDto userDto, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(userDto.Username, password, isPersistent: false, lockoutOnFailure: false);

        return result;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
    
    public async Task<string> Authenticate(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            return null;
        }
        
        const string token = "LoginToken";

        return token;
    }
}