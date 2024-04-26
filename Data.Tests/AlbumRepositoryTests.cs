using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using PhotoGallery.Data;
using PhotoGallery.Data.Repository;
using PhotoGallery.Entities;

namespace Data.Tests
{
    public class AlbumRepositoryTests
    {
        private GalleryDbContext _context;
        private AlbumRepository _repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<GalleryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

            _context = new GalleryDbContext(options, operationalStoreOptions);
            _repo = new AlbumRepository(_context);
        }

        [Test]
        public async Task AddAsync_AlbumIsAdded_AlbumIsSavedInContext()
        {
            var album = new Album();

            await _repo.AddAsync(album);

            ClassicAssert.AreEqual(1, _context.AlbumDtos.Count());
            var firstAddedAlbumDto = _context.AlbumDtos.First();
            var mappedAlbum = Album.Map(firstAddedAlbumDto);    // Assuming you have this method
            ClassicAssert.AreEqual(album, mappedAlbum);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}