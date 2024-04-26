using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PhotosController : ControllerBase
{
    private readonly IPhotoService<PhotoModel> _photoService;

    public PhotosController(IPhotoService<PhotoModel> photoService)
    {
        _photoService = photoService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPhoto(PhotoModel model)
    {
        await _photoService.AddAsync(model);
        return Ok(new {message = "Photo added"});
        
    }
    
    [HttpGet("/album/{albumId}")]
    public async Task<IActionResult> GetAllByAlbumId(int albumId)
    {
        var photos = await _photoService.GetAllByAlbumIdAsync(albumId);
        return Ok(photos);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        await _photoService.DeleteAsync(id);
        return Ok(new {message = "Photo deleted"});
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePhoto(PhotoModel model)
    {
        await _photoService.UpdateAsync(model);
        return Ok(new {message = "Photo updated"});
    }
    
    [HttpPost("{photoId}/like")]
    public async Task<IActionResult> LikePhoto(Guid photoId)
    {
        await _photoService.LikePhotoAsync(photoId);
        return Ok(new { message = "Photo liked!" });
    }
    
    [HttpPost("{photoId}/dislike")]
    public async Task<IActionResult> DislikePhoto(Guid photoId)
    {
        await _photoService.DislikePhotoAsync(photoId);
        return Ok(new { message = "Photo disliked!" });
    }
}