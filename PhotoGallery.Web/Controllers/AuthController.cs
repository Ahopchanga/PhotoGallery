using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request.User, request.Password);

        if (result.Succeeded)
        {
            return Ok(new { message = "Registration successful." });
        }

        return BadRequest(result.Errors);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.Authenticate(request.Username, request.Password);

        if (!string.IsNullOrEmpty(token))
        {
            return Ok(new { token = token });
        }

        return Unauthorized(new { message = "Invalid username or password." });
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return Ok(new { message = "Logged out successfully." });
    }
}