using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoGallery.Interfaces.Repositories;

namespace PhotoGallery.Data;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GalleryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            },
            ServiceLifetime.Transient
        );
        
        return services;
    }
}