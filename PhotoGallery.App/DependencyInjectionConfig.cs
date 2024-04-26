using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.App.Models;
using PhotoGallery.App.Services;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.App;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAlbumService<AlbumModel>, AlbumService>();

        return services;
    }
}