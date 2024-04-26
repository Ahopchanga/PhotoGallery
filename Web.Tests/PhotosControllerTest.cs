using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Services;
using PhotoGallery.Web.Controllers;

namespace Web.Tests;

[TestFixture]
public class PhotosControllerTest
{
    private Mock<IPhotoService<PhotoModel>> _mockPhotoService;
    private PhotosController _photosController;

    [SetUp]
    public void Setup()
    {
        _mockPhotoService = new Mock<IPhotoService<PhotoModel>>();
        _photosController = new PhotosController(_mockPhotoService.Object);
    }

    [Test]
    public async Task AddPhoto_ModelIsValid_ReturnsOkResult()
    {
        // Arrange
        var photoModel = new PhotoModel
        {
            PhotoId = Guid.NewGuid(),
            AlbumId = 1,
            Title = "Test Photo",
            Description = "This is a test photo",
            Path = "path/to/photo.jpg",
            DateUploaded = DateTime.Now,
            LikeCount = 0,
            DislikeCount = 0,
            ImageFile = null
        };

        _mockPhotoService
            .Setup(service => service.AddAsync(It.IsAny<PhotoModel>()))
            .Returns(Task.CompletedTask); 

        // Act
        var result = await _photosController.AddPhoto(photoModel);

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }

    [TearDown]
    public void TearDown()
    {
        _mockPhotoService = null;
        _photosController = null;
    }
}