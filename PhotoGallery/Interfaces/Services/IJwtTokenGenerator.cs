namespace PhotoGallery.Interfaces.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(string username);
}