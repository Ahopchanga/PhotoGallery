using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.App.Models;
using PhotoGallery.Interfaces.Services;

namespace PhotoGallery.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumService<AlbumModel> _albumService;

    public AlbumsController(IAlbumService<AlbumModel> albumService)
    {
        _albumService = albumService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAlbum([FromBody] AlbumModel model)
    {
        await _albumService.AddAsync(model);
        return Ok(new {message = "Album created"});
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlbum(int id)
    {
        var album = await _albumService.GetByIdAsync(id);
        return Ok(album);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAlbums(int pageNumber, int pageSize)
    {
        var albums = await _albumService.GetAllAsync(pageNumber, pageSize);
        return Ok(albums);
    }
    
    [Authorize] 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        await _albumService.DeleteAsync(id);
        return Ok(new {message = "Album deleted"});
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAlbum([FromBody] AlbumModel model)
    {
        await _albumService.UpdateAsync(model);
        return Ok(new {message = "Album updated"});
    }
}