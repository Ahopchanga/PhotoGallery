using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhotoGallery.DTOs;
using PhotoGallery.Entities;

namespace PhotoGallery.Data;

public class GalleryDbContext : ApiAuthorizationDbContext<User>
{
    public GalleryDbContext(
        DbContextOptions options, 
        IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
    
    public DbSet<UserDto> UserDtos { get; set; }
    
    public DbSet<AlbumDto> AlbumDtos { get; set; }
    
    public DbSet<PhotoDto> PhotoDtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<UserDto>()
            .HasKey(u => u.UserId);
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Role).HasDefaultValue("DefaultRole");
        });
        modelBuilder.Entity<AlbumDto>()
            .HasKey(a => a.AlbumId);
        
        modelBuilder.Entity<AlbumDto>()
            .HasOne(a => a.User)
            .WithMany(u => u.Albums)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<PhotoDto>()
            .HasKey(p => p.PhotoId);

        modelBuilder.Entity<PhotoDto>()
            .HasOne(p => p.Album)
            .WithMany(a => a.Photos)
            .HasForeignKey(p => p.AlbumId);
    }
}