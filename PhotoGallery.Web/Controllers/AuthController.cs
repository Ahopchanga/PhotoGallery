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
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authService.RegisterAsync(Entities.User.Map(request.User), request.Password);

        if (result.Succeeded)
        {
            return Ok(new { message = "Registration successful." });
        }

        return BadRequest(result.Errors);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
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