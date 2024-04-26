using System.Security.Claims;

namespace PhotoGallery.Interfaces.Services;

public interface IJwtTokenGenerator 
{
    string GenerateToken(string username);
    string GenerateTokenWithClaims(IList<Claim> claims);
}