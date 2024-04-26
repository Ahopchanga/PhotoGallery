using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.App.Models;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<User> _userManager;

    public AuthController(IAuthService authService, UserManager<User> userManager)
    {
        _authService = authService;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        request.User.Role = request.Role;

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

        var user = await _userManager.FindByNameAsync(request.Username);
        var userRole = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, request.Username),
            new(ClaimTypes.Role, userRole[0])
        };
    
        var token = await _authService.Authenticate(request.Username, request.Password, claims);

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