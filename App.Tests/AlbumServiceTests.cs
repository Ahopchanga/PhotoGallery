using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using PhotoGallery.App.Services;
using PhotoGallery.Entities;
using PhotoGallery.Interfaces.Repositories;

namespace App.Tests;

public class AlbumServiceTests
{
    private Mock<IAlbumRepository> _mockAlbumRepository;
    private Mock<IWebHostEnvironment> _mockEnvironment;
    private AlbumService _service;

    [SetUp]
    public void Setup()
    {
        _mockAlbumRepository = new Mock<IAlbumRepository>();
        _mockEnvironment = new Mock<IWebHostEnvironment>();
        _service = new AlbumService(_mockAlbumRepository.Object, _mockEnvironment.Object);
    }

    [Test]
    public async Task GetByIdAsync_AlbumExists_ReturnsCorrectModel()
    {
        // Arrange
        var testAlbum = new Album { AlbumId = 1 };
        _mockAlbumRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(testAlbum);

        // Act
        var returnedModel = await _service.GetByIdAsync(1);

        // Assert
        ClassicAssert.AreEqual(testAlbum.AlbumId, returnedModel.AlbumId);
        _mockAlbumRepository.Verify(repo => repo.GetByIdAsync(1), Times.Once);
    }

    [TearDown]
    public void TearDown()
    {
        _mockAlbumRepository = null;
        _mockEnvironment = null;
        _service = null;
    }
}