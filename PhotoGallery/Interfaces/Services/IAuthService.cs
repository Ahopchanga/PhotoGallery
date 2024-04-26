using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PhotoGallery.DTOs;

namespace PhotoGallery.Interfaces.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserDto userDto, string password);
    Task<SignInResult> LoginAsync(UserDto userDto, string password);
    Task LogoutAsync();
    Task<string> Authenticate(string username, string password, IList<Claim> claims);
}