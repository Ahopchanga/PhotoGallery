using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhotoGallery.App.Models;
using PhotoGallery.App.Services;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAlbumService<AlbumModel>, AlbumService>();
        services.AddTransient<IPhotoService<PhotoModel>, PhotoService>();
        services.AddTransient<IUserService<UserModel>, UserService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
        });

        return services;
    }
}